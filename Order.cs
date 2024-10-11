using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataGrid
{
    public partial class Order
    {
        public string _id { get; set; } 
        public string userName { get; set; }
        public string productName { get; set; }
        public int quantity { get; set; }
        public string date { get; set; }
    }
}
