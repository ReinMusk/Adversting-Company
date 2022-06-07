using Adversting_Company.dbo;
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

namespace Adversting_Company
{
    /// <summary>
    /// Interaction logic for Empl_Del.xaml
    /// </summary>
    public partial class Empl_Del : Page
    {
        public static ObservableCollection<Employee> Empl { get; set; }
        public Empl_Del()
        {
            InitializeComponent();
            Empl = new ObservableCollection<Employee>(Bd_connection.connection.Employee.ToList());
            this.DataContext = this;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var info = (sender as ListView).SelectedItem as Employee;
            if (MessageBox.Show($"Уволить сотрудника {info.Name} {info.Surname}", "question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Bd_connection.connection.Employee.Remove(info);
                Bd_connection.connection.SaveChanges();
                NavigationService.Navigate(new Page_Log(Page_Log.pos));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page_Log(Page_Log.pos));
        }
    }
}
