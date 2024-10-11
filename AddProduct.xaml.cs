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
    public partial class AddProduct : Window
    {
        BindingList<Product> products;
        public AddProduct(BindingList<Product> productBindingList)
        {
            InitializeComponent();

            products = new BindingList<Product>();

            foreach (Product product in productBindingList)
            {
                products.Add(product);
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
            var product = new Product()
            {
                name = nameTextBox.Text,
                price = int.Parse(priceTextBox.Text),
                producer = producerTextBox.Text,
                manufacture = int.Parse(manufactureTextBox.Text)
            };

            PostDataAsync(product);
        }

        // Api logic
        static async Task PostDataAsync(Product product)
        {
            try
            {
                string apiUrl = "http://localhost:8000/api/product/create";

                // Chuyển đối tượng Product thành chuỗi JSON
                string jsonData = JsonConvert.SerializeObject(product);

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
