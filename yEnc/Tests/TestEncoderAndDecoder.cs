using System;
using System.IO;
using NUnit.Framework;

namespace yEnc.Tests
{
	[TestFixture]
	public class TestEncoderAndDecoder
	{
		[Test]
		public void NormalUsageTest()
		{
			//Test normal usage - encode to a file, then open the file and decode it.  
			const int sampleSize = 100000;
			const int batchSize = 500;
			const string sampleFileName = "encodedSample.BIN";
			byte[] original = new byte[sampleSize];
			new System.Random().NextBytes(original);

			YEncEncoder encoder = new YEncEncoder();
			FileStream fs = new FileStream
				(sampleFileName, FileMode.Create, FileAccess.Write, FileShare.Write);
			try
			{
				for (int i=0; i<sampleSize/batchSize; i++)
				{
					bool flush = false;
					int startByte = i * batchSize;
					if (startByte + batchSize == sampleSize) 
						flush = true;

					int destSize = encoder.GetByteCount(original, startByte, batchSize, flush);
					byte[] destBatch = new byte[destSize];
					int bytesWritten = encoder.GetBytes(original, startByte, batchSize, destBatch, 0, flush);

					Assert.AreEqual(destSize, bytesWritten, "GetGyteCount must return the same as GetBytes");

					//here is where we would write off the batch to a file.  Lets do that.
					fs.Write(destBatch, 0, bytesWritten);
				}
			} 
			finally
			{
				fs.Close();
			}

			YEncDecoder decoder = new YEncDecoder();
			FileStream fs2 = new FileStream
				(sampleFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
			byte[] decoded = new byte[sampleSize];	//I have faith, it will be right :)
			int destIndex = 0;
			try
			{
				byte[] buffer = new byte[batchSize];
				int bytesRead = fs2.Read(buffer, 0, batchSize);
				while (bytesRead > 0)
				{
					int expectedBytes = decoder.GetByteCount(buffer, 0, bytesRead, false);
					int decodedBytes = decoder.GetBytes(buffer, 0, bytesRead, decoded, destIndex, false);
					
					Assert.AreEqual(expectedBytes, decodedBytes, "GetByteCount should return the same as GetBytes");

					destIndex += decodedBytes;
					bytesRead = fs2.Read(buffer, 0, batchSize);
				}
				decoder.GetBytes(new byte[0], 0, 0, decoded, destIndex, true);	//force a flush
			} 
			finally
			{
				fs2.Close();
				File.Delete(sampleFileName);
			}

			//final checks
			System.Diagnostics.Debug.WriteLine("original: " + BitConverter.ToString(new CRC32().ComputeHash(original, 0, sampleSize)));
			System.Diagnostics.Debug.WriteLine("encoder: " + BitConverter.ToString(encoder.CRCHash));
			System.Diagnostics.Debug.WriteLine("decoder: " + BitConverter.ToString(decoder.CRCHash));

			Assert.AreEqual(BitConverter.ToString(new CRC32().ComputeHash(original)), 
				BitConverter.ToString(encoder.CRCHash), 
				"Encoder should match original hash");
			Assert.AreEqual(BitConverter.ToString(new CRC32().ComputeHash(original)), 
				BitConverter.ToString(decoder.CRCHash), 
				"Decoder should match original hash");
			Assert.AreEqual(BitConverter.ToString(encoder.CRCHash), BitConverter.ToString(decoder.CRCHash), 
				"The CRC32 hashes should match");

			for(int i=0; i<sampleSize; i++)
			{
				Assert.AreEqual(original[i], decoded[i], "Final check failed at byte " + i.ToString());
			}
		}

		[Test]
		public void SampleEncode()
		{
			FileStream fs = File.OpenRead(@"..\..\Samples\TestFile.bin");	

			try
			{
				byte[] original = new byte[4096];
				int originalBytes = fs.Read(original, 0, 4096);
				Assert.AreEqual(584, originalBytes, "Unexpected amount of bytes read.");

				//test file encodes period(46) and tab(9), and follows with CRLF
				YEncEncoder encoder = new YEncEncoder(128, new byte[] {46,9}, true);
				byte[] encoded = new byte[4096];

				int encodedBytes = encoder.GetBytes(original, 0, originalBytes, encoded, 0, true);

				Assert.AreEqual(606, encodedBytes, "Test file supplied encodes to 606");
				FileStream fs2 = File.OpenRead(@"..\..\Samples\Encoded.bin");

				try
				{
					byte[] check = new byte[4096];
					int checkBytes = fs2.Read(check, 0, 4096);

					Assert.AreEqual(606, checkBytes, "We expect 606 bytes");

					for(int i=0; i<checkBytes; i++)
					{
						Assert.AreEqual(check[i], encoded[i], "Checked against sample encoded failed on byte " + i.ToString());
					}

					CRC32 extraCheck = new CRC32();
					extraCheck.ComputeHash(original, 0, originalBytes);
					byte[] extraCheckCRC = extraCheck.Hash;
					byte[] actualCRC = encoder.CRCHash;
					byte[] expectedCRC = new byte[] {0xde,0xd2,0x9f,0x4f};
					
					Assert.AreEqual(BitConverter.ToString(expectedCRC), BitConverter.ToString(extraCheckCRC), "CRC mismatch, due to CRC algorithm failure?");
					Assert.AreEqual(BitConverter.ToString(expectedCRC), BitConverter.ToString(actualCRC), "CRC mismatch");
				}
				finally
				{
					fs2.Close();
				}
			} 
			finally
			{
				fs.Close();
			}
		}

		[Test]
		public void SampleDecode()
		{
			FileStream fs = File.OpenRead(@"..\..\Samples\Encoded.bin");

			try
			{
				byte[] encoded = new byte[4096];
				int encodedBytes = fs.Read(encoded, 0, 4096);

				YEncDecoder decoder = new YEncDecoder();
				byte[] decoded = new byte[4096];

				int decodedBytes = decoder.GetBytes(encoded, 0, encodedBytes, decoded, 0, true);

				Assert.AreEqual(584, decodedBytes, "Test file supplied was 584 before encoding");
				byte counter = 255;
				for(int i=0x24; i<0x124; i++)
				{
					Assert.AreEqual(counter, decoded[i], "Checking against 255..0 failed on byte " + i.ToString());
					counter--;
				}
			} 
			finally
			{
				fs.Close();
			}
		}

		[Test]
		public void BinaryTest()
		{
			//create a binary
			const int sampleSize = 2000;
			byte[] original = new byte[sampleSize];
			new System.Random().NextBytes(original);

			YEncEncoder encoder = new YEncEncoder();
			byte[] encoded = new byte[4096];
			int encodedBytes = encoder.GetBytes(original, 0, sampleSize, encoded, 0, true);

			Assert.IsTrue(encodedBytes > sampleSize, "Should always be larger than original");

			YEncDecoder decoder = new YEncDecoder();
			byte[] decoded = new byte[4096];
			int decodedBytes = decoder.GetBytes(encoded, 0, encodedBytes, decoded, 0, true);

			Assert.AreEqual(sampleSize, decodedBytes, "Should decode back to the orginal length");
			
			for(int i=0; i<sampleSize; i++)
			{
				Assert.AreEqual(original[i], decoded[i], "Each byte should match, failed on " + i.ToString());
			}
		}

		[Test]
		public void BasicTest()
		{
			YEncEncoder encoder = new YEncEncoder();
			string toEncode = "encode me";
			byte[] source = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
			byte[] dest = new byte[4096];

			int numBytes = encoder.GetBytes(source, 0, source.Length, dest, 0, true);

			Assert.IsTrue(numBytes != 0, "Should convert some bytes");
			Assert.AreEqual(source.Length, numBytes, "No escaped chars, so should be the same length");

			Assert.AreEqual(numBytes, encoder.GetByteCount(source, 0, source.Length, true), 
				"GetByteCount should return the same count as the actual encoding");

			YEncDecoder decoder = new YEncDecoder();
			Assert.AreEqual(source.Length, decoder.GetByteCount(dest, 0, numBytes, true), 
				"Should return same number of chars as original");

			byte[] source2 = new byte[4096];
			int numBytes2 = decoder.GetBytes(dest, 0, numBytes, source2, 0, true);

			Assert.AreEqual(numBytes, numBytes2, "Should decode to the same number of chars");
			string finalText = System.Text.ASCIIEncoding.ASCII.GetString(source2, 0, numBytes2);

			Assert.AreEqual(toEncode, finalText, "Decoded back to original text");

			//			string result = System.Text.ASCIIEncoding.ASCII.GetString(bytes, 0, numBytes);
			//			System.Diagnostics.Debug.WriteLine(result);
		}

	}
}
