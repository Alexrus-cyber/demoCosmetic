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

namespace RussianCosmetic
{
    /// <summary>
    /// Interaction logic for OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        public OrdersPage()
        {
            InitializeComponent();
            if (MainWindow.user != null)
            {
                ListOrdersAdmin.Visibility = Visibility.Visible;
                ListOrders.Visibility = Visibility.Collapsed;
                ListOrdersAdmin.ItemsSource = st1_Rassadin_CosmeticEntities1.GetContext().Order.ToList();
              
            }
            else
            {
                ListOrdersAdmin.Visibility = Visibility.Collapsed;
                ListOrders.Visibility = Visibility.Visible;
                ListOrders.ItemsSource = st1_Rassadin_CosmeticEntities1.GetContext().Order.ToList();
            }
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPageServices((sender as Button).DataContext as Order));
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var _currentSearch = st1_Rassadin_CosmeticEntities1.GetContext().Order.ToList();
            _currentSearch = _currentSearch.Where(p => p.codeClient.Trim().ToLower().Contains(searchBox.Text.Trim().ToLower())).ToList();
            ListOrders.ItemsSource = _currentSearch.ToList();
            ListOrdersAdmin.ItemsSource = _currentSearch.ToList();
        }
    }
}
