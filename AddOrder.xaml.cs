using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AddNewProduct.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        BindingList<Order> orders;

        public AddOrder(BindingList<Order> orderBindingList)
        {
            InitializeComponent();

            orders = new BindingList<Order>();

            foreach (Order order in orderBindingList)
            {
                orders.Add(order);
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        // Button logic
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            var order = new Order()
            {
                date = dateTextBox.Text,
                userName = userNameTextBox.Text,
                productName = productNameTextBox.Text,
                quantity = int.Parse(quantityTextBox.Text)
            };

            PostDataAsync(order);
        }

        // Api logic
        static async Task PostDataAsync(Order order)
        {
            try
            {
                string apiUrl = "http://localhost:8000/api/order/create";

                // Chuyển đối tượng Product thành chuỗi JSON
                string jsonData = JsonConvert.SerializeObject(order);

                MessageBox.Show(jsonData);

                // Tạo HttpClient để thực hiện cuộc gọi POST
                using (HttpClient client = new HttpClient())
                {
                    // Tạo nội dung của yêu cầu POST với kiểu dữ liệu là JSON
                    StringContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");

                    // Thực hiện cuộc gọi POST
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    // Kiểm tra xem cuộc gọi API có thành công không (mã trạng thái 2xx)
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("API POST successful!");
                    }
                    else
                    {
                        MessageBox.Show($"API POST failed. Status Code: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
