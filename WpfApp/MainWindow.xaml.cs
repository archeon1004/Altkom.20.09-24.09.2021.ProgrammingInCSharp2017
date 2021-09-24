using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Orders = new ObservableCollection<Order>();
            DataContext = this;

        }

        public ObservableCollection<Order> Orders { get;}

        public string Hello => "HELLO!!!";

        private void CoffeeControl_OrderPlaced(object sender, EventArgs e)
        {
            var coffeecontrol = sender as CoffeeControl;
            Orders.Add(coffeecontrol.Order);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            Orders.Remove((Order)button.DataContext);
        }
    }
}
