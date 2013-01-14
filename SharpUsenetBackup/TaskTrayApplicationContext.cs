using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SharpUsenetBackup;

namespace TaskTrayApplication
{
    public class TaskTrayApplicationContext : ApplicationContext
    {
        NotifyIcon notifyIcon = new NotifyIcon();
        MainForm mainWindow = new MainForm();

        public TaskTrayApplicationContext()
        {
            MenuItem configMenuItem = new MenuItem("Main Window", new EventHandler(ShowMainWindow));
            MenuItem exitMenuItem = new MenuItem("Exit", new EventHandler(Exit));

            notifyIcon.Icon = SharpUsenetBackup.Properties.Resources.AppIcon;
            notifyIcon.DoubleClick += new EventHandler(ShowMainWindow);
            notifyIcon.ContextMenu = new ContextMenu(new MenuItem[] { configMenuItem, exitMenuItem });
            notifyIcon.Visible = true;

            // If we are already showing the window meerly focus it.
            if (mainWindow.Visible)
                mainWindow.Focus();
            else
                mainWindow.ShowDialog();
        }

        void ShowMainWindow(object sender, EventArgs e)
        {
            // If we are already showing the window meerly focus it.
            if (mainWindow.Visible)
                mainWindow.Focus();
            else
                mainWindow.ShowDialog();
        }

        void Exit(object sender, EventArgs e)
        {
            // We must manually tidy up and remove the icon before we exit.
            // Otherwise it will be left behind until the user mouses over.
            notifyIcon.Visible = false;

            Application.Exit();
        }
    }
}
