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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        MainWindow main1;
        public LoginPage(MainWindow main)
        {
            InitializeComponent();
            main1 = main;
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            bool success = Logining(Login.Text, Password.Text);
            if (success)
            {
                var u = GoodLog(Login.Text, Password.Text);
                MainWindow.user = u;
                main1.MainFrame.Navigate(new OrdersPage());
                MessageBox.Show("Вы вошли в систему");
                main1.OrderBtn.Visibility = Visibility.Visible;
                main1.LoginBtn.Visibility = Visibility.Hidden;
                main1.NameEmployee.Text = u.FIO;
            }
            else
            {
                MessageBox.Show("Вы ошиблись");
            }
        }

        private bool Logining(string login, string password)
        {
           return st1_Rassadin_CosmeticEntities1.GetContext().Employee.Any(p => p.login == login && p.password == password);
        }
        private Employee GoodLog(string login, string password)
        {
            return st1_Rassadin_CosmeticEntities1.GetContext().Employee.FirstOrDefault(p => p.login == login && p.password == password);
        }
    }
}
