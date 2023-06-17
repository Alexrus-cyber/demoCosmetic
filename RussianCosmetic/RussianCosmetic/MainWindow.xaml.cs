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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Employee user;
        public MainWindow()
        {
            InitializeComponent();
            OrderBtn.Visibility = Visibility.Hidden;
            Manager.MainFrame = MainFrame;
            MainFrame.Navigate(new OrdersPage());
           
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new LoginPage(this));
        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddEditPageServices(null));
        }
    }
}
