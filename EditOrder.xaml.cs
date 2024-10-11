using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for ProductEdit.xaml
    /// </summary>
    public partial class EditOrder : Window
    {
        public static int Index;

        BindingList<Order> orders;
        public EditOrder(int index, BindingList<Order> orderBindingList)
        {
            InitializeComponent();

            Index = index;
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
                userName = userNameTextBox.Text,
                productName = productNameTextBox.Text,
                quantity = int.Parse(quantityTextBox.Text),
                date = dateTextBox.Text
            };

            UpdateDataAsync(order, orders[Index]._id);
        }

        // Api logic
        static async Task UpdateDataAsync(Order order, string orderId)
        {
            try
            {
                string apiUrl = $"http://localhost:8000/api/order/{orderId}";

                // Chuyển đối tượng Product thành chuỗi JSON
                string jsonData = JsonConvert.SerializeObject(order);

                MessageBox.Show(jsonData);

                // Tạo HttpClient để thực hiện cuộc gọi POST
                using (HttpClient client = new HttpClient())
                {
                    // Tạo nội dung của yêu cầu PUT hoặc PATCH
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    // Thực hiện cuộc gọi PUT hoặc PATCH
                    HttpResponseMessage response = await client.PutAsync(apiUrl, content);

                    // Kiểm tra xem cuộc gọi API có thành công không (mã trạng thái 2xx)
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("API EDIT successful!");
                    }
                    else
                    {
                        MessageBox.Show($"API EDIT failed. Status Code: {response.StatusCode}");
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