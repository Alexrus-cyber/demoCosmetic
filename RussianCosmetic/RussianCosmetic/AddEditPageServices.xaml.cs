using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// Interaction logic for AddEditPageServices.xaml
    /// </summary>
    public partial class AddEditPageServices : Page
    {
        Order _currentOrder = new Order();
        public AddEditPageServices(Order selected)
        {
            InitializeComponent();
            if (selected != null)
            {
               _currentOrder = selected;
            }
            DataContext = _currentOrder;
            CodeClient.ItemsSource = st1_Rassadin_CosmeticEntities1.GetContext().Client.ToList();
            EmloyeeList.ItemsSource = st1_Rassadin_CosmeticEntities1.GetContext().Employee.ToList();       
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            _currentOrder.numberOfOrder = $"{_currentOrder.Client.code.Trim().ToString() + "/" + DateTime.Today.ToString()}";
            _currentOrder.dateStart = DateTime.Today;
            _currentOrder.services = "94, 42, 42";
            if (_currentOrder.id == 0)
            {
                st1_Rassadin_CosmeticEntities1.GetContext().Order.Add(_currentOrder);
            }
            try
            {
                st1_Rassadin_CosmeticEntities1.GetContext().SaveChanges();
                MessageBox.Show("Вы создали запрос");
                Manager.MainFrame.Navigate(new OrdersPage());
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}
