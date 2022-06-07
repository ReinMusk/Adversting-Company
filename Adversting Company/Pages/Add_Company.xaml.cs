using Adversting_Company.dbo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Adversting_Company
{
    /// <summary>
    /// Interaction logic for Add_Company.xaml
    /// </summary>
    public partial class Add_Company : Page
    {
        public static ObservableCollection<Employee> Empl { get; set; }
        int i { get; set; }
        public Add_Company()
        {
            InitializeComponent();
            Empl = new ObservableCollection<Employee>(Bd_connection.connection.Employee.ToList());
            this.DataContext = this;
        }
        private void position_txt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ComboBox).SelectedItem as Employee;
            i = a.Id;
        }
        private void registation_event(object sender, RoutedEventArgs e)
        {
            var a = new Company
            {
                Name = name_txt.Text,
                Address = adress_txt.Text,
                Number = number_txt.Text,
                Employee_id = i
            };
            Bd_connection.connection.Company.Add(a);
            Bd_connection.connection.SaveChanges();
            MessageBox.Show("OK");
            NavigationService.Navigate(new Page_Log(Page_Log.pos));
        }
        private void reverse_event(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page_Log(Page_Log.pos));
        }
    }
}
