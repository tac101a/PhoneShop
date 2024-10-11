using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DataGrid.Properties;

namespace DataGrid
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Check if a user is logged in (i.e., a token exists)
            if (!string.IsNullOrWhiteSpace(DataGrid.Properties.Settings.Default.UserToken))
            {
                // If logged in, show the main window
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            else
            {
                // If not logged in, show the login window
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
            }
        }
    }

}
