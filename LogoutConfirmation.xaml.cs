using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DataGrid
{
    /// <summary>
    /// Interaction logic for LogoutConfirmation.xaml
    /// </summary>
    public partial class LogoutConfirmation : Window
    {
        public LogoutConfirmation()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        // Button logic
        private void yesButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear the saved token
            Properties.Settings.Default.UserToken = string.Empty;
            Properties.Settings.Default.IsLoggedIn = false;
            Properties.Settings.Default.Save();
            // Find and close the main window
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    window.Close();
                    break;
                }
            }

            // Open the login window
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();

            // Close the current logout confirmation window
            this.Close();

        }

        private void noButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

