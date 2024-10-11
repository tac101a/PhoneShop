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
    /// Interaction logic for DeleteConfirmation.xaml
    /// </summary>
    public partial class DeleteConfirmation : Window
    {
        public static int Index;

        public static BindingList<Product> products;

        public DeleteConfirmation(int index, BindingList<Product> productBindingList)
        {
            InitializeComponent();

            Index = index;
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

        private async void yesButton_Click(object sender, RoutedEventArgs e)
        {
            await DeleteDataAsync(products[Index]);
            this.Close();
        }

        private void noButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Api logic
        static async Task DeleteDataAsync(Product product)
        {
            try
            {
                string apiUrl = $"http://localhost:8000/api/product/{product._id}";

                // Tạo HttpClient để thực hiện cuộc gọi POST
                using (HttpClient client = new HttpClient())
                {

                    // Thực hiện cuộc gọi POST
                    HttpResponseMessage response = await client.DeleteAsync(apiUrl);

                    // Kiểm tra xem cuộc gọi API có thành công không (mã trạng thái 2xx)
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("API DELETE successful!");
                    }
                    else
                    {
                        MessageBox.Show($"API DELETE failed. Status Code: {response.StatusCode}");
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
