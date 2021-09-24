using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    public partial class CoffeeControl : UserControl
    {
        public CoffeeControl()
        {
            InitializeComponent();
        }
        public Order Order { get; set; } = new Order();

        public event EventHandler<EventArgs> OrderPlaced;
        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            Order.DateTime = DateTime.Now;
            if (OrderPlaced != null)
                OrderPlaced(this, EventArgs.Empty);
            Order = (Order)Order.Clone();
        }

        private void radCoffee_Checked(object sender, RoutedEventArgs e) { Order.Beverage = "Coffee"; }
        private void radTea_Checked(object sender, RoutedEventArgs e) { Order.Beverage = "Tea"; }
        private void radMilk_Checked(object sender, RoutedEventArgs e) { Order.Milk = "Milk"; }
        private void radNoMilk_Checked(object sender, RoutedEventArgs e) { Order.Milk = "No Milk"; }
        private void radSugar_Checked(object sender, RoutedEventArgs e) { Order.Sugar = "Sugar"; }
        private void radNoSugar_Checked(object sender, RoutedEventArgs e) { Order.Sugar = "No Sugar"; }
    }
}