using System;
using System.IO;
using System.Security.Cryptography;
using NUnit.Framework;

namespace yEnc.Tests
{
	[TestFixture]
	public class TestCryptoStream
	{
		[Test]
		public void BasicStringTest()
		{
			//writing
			MemoryStream ms = new MemoryStream();  //this could be any stream we want to write to

			YEncEncoder encoder = new YEncEncoder();
 			CryptoStream cs = new CryptoStream(ms, encoder, CryptoStreamMode.Write);
			StreamWriter w = new StreamWriter(cs);
			w.Write("Test string");
			w.Flush();
			cs.Flush();

			//reading back from the memorystream
			ms.Position = 0;		
			YEncDecoder decoder = new YEncDecoder();
			CryptoStream cs2 = new CryptoStream(ms, decoder, CryptoStreamMode.Read);
			StreamReader r = new StreamReader(cs2);
			string finalText = r.ReadToEnd();

			Assert.AreEqual("Test string", finalText);
		}

		[Test]
		public void FullByteRangeTest()
		{
			//writing
			MemoryStream ms = new MemoryStream();  //this could be any stream we want to write to

			YEncEncoder encoder = new YEncEncoder();
			CryptoStream cs = new CryptoStream(ms, encoder, CryptoStreamMode.Write);

			byte[] bytes = new byte[256];
			for(int i=byte.MinValue; i<=byte.MaxValue; i++)
			{
				bytes[i] = (byte)i;
			}

			BinaryWriter w = new BinaryWriter(cs);
			w.Write(bytes, 0, 256);
			w.Flush();
			cs.Flush();

			//reading back from the memorystream
			ms.Position = 0;		
			YEncDecoder decoder = new YEncDecoder();
			CryptoStream cs2 = new CryptoStream(ms, decoder, CryptoStreamMode.Read);

			BinaryReader r = new BinaryReader(cs2);
			byte[] newBytes = r.ReadBytes(256);

			Assert.AreEqual(BitConverter.ToString(bytes, 0, 256), BitConverter.ToString(newBytes, 0, 256));
		}

	}
}
