using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(passwordBox.Password) && passwordBox.Password.Length > 0)
                textPassword.Visibility = Visibility.Collapsed;
            else
                textPassword.Visibility = Visibility.Visible;
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            passwordBox.Focus();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // Check if the email field is empty
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please enter your email (or username).", "Input Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Check if the password field is empty
            if (string.IsNullOrWhiteSpace(passwordBox.Password))
            {
                MessageBox.Show("Please enter your password.", "Input Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            bool loginSuccess = await AttemptLogin(txtEmail.Text, passwordBox.Password);
            if (loginSuccess)
            {
                MessageBox.Show("Login successful.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login failed. Please check your credentials.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private async Task<bool> AttemptLogin(string credential, string password)
        {
            try
            {
                HttpClient client = new HttpClient();
                var loginInfo = new { emailOrUserName = credential, userPassword = password };
                StringContent content = new StringContent(JsonConvert.SerializeObject(loginInfo), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("http://localhost:8000/api/auth/login", content);

                if (response.IsSuccessStatusCode)
                {
                    // Handle the response here. Extract the token if your API provides one and store it for future requests.
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var jsonResponse = JsonConvert.DeserializeObject<dynamic>(responseContent);
                    var token = (string)jsonResponse.token; // Capture the token from the response

                    // Save the token and other necessary information locally
                    Properties.Settings.Default.UserToken = token;
                    Properties.Settings.Default.IsLoggedIn = true;
                    Properties.Settings.Default.Save();
                    return true;
                }
                else
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var errorResponse = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseContent);
                    MessageBox.Show("Login failed. Please check your credentials.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        private void txtEmail_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && txtEmail.Text.Length > 0)
                textEmail.Visibility = Visibility.Collapsed;
            else
                textEmail.Visibility = Visibility.Visible;
        }

        private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtEmail.Focus();
        }

        private void signUpButton_Click(object sender, RoutedEventArgs e)
        {
            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.Show();
            this.Close(); 
        }
    }
}
