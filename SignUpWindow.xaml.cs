using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        public SignUpWindow()
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void orLoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordHintTextBlock.Visibility = Visibility.Visible;
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            PasswordHintTextBlock.Visibility = Visibility.Collapsed;
        }
        private async void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // First, check if the TermsCheckBox is checked
                if (!TermsCheckBox.IsChecked ?? false)
                {
                    MessageBox.Show("You must agree to the terms and conditions before signing up.", "Terms Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Check each field and display a message if any are empty
                if (string.IsNullOrWhiteSpace(UsernameTextBox.Text))
                {
                    MessageBox.Show("Please enter your username.", "Input Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
                {
                    MessageBox.Show("Please enter your email.", "Input Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(PasswordBox.Password))
                {
                    MessageBox.Show("Please enter your password.", "Input Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(RepeatPasswordBox.Password))
                {
                    MessageBox.Show("Please repeat your password.", "Input Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var name = string.Empty;
                var username = UsernameTextBox.Text;
                var _email = EmailTextBox.Text;
                var password = PasswordBox.Password;
                var repeatPassword = RepeatPasswordBox.Password;

                // Optional: Validate the inputs (e.g., check if passwords match)
                if (!IsValidEmail(_email))
                {
                    MessageBox.Show("Email format is invalid.", "Invalid Email", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (!IsValidPassword(password))
                {
                    MessageBox.Show("Password must be at least 8 characters long and include both letters and numbers.", "Invalid Password", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (password != repeatPassword)
                {
                    MessageBox.Show("Passwords do not match.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                HttpClient client = new HttpClient();
                var model = new
                {
                    name = username, // By default, name of user is userName
                    userName = username,
                    email = _email,
                    userPassword = password
                };

                StringContent content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("http://localhost:8000/api/auth/register", content);

                
                string result = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Registration successful", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    // Navigate to login window
                    LoginWindow loginWindow = new LoginWindow();
                    loginWindow.Show();
                    this.Close();
                }
                else
                {
                    var errorResponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
                    if (errorResponse.ContainsKey("message") && errorResponse["message"].ToString().Contains("already exists"))
                    {
                        MessageBox.Show("Username or email already exists. Please use a different one.", "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        MessageBox.Show($"Registration failed: {result}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            return Regex.IsMatch(email, pattern);
        }

        private bool IsValidPassword(string password)
        {
            // This regex will check for a password that is at least 8 characters long and contains a number and a letter.
            string pattern = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$";
            return Regex.IsMatch(password, pattern);
        }

        private void TermsHyperlink_Click(object sender, RoutedEventArgs e)
        {
            TermsAndConditionsDialog dialog = new TermsAndConditionsDialog();
            dialog.ShowDialog();
        }
    }
}
