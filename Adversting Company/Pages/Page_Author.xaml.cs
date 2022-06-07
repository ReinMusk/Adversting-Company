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
    /// Interaction logic for Page_Author.xaml
    /// </summary>
    public partial class Page_Author : Page
    {
        public static int compid;
        public static ObservableCollection<Employee> Users { get; set; }
        public static ObservableCollection<Company> Comp { get; set; }
        public Page_Author()
        {
            InitializeComponent();
            Comp = new ObservableCollection<Company>(Bd_connection.connection.Company.ToList());
            this.DataContext = this;
        }

        private void Autho_event(object sender, RoutedEventArgs e)
        {
            Users = new ObservableCollection<Employee>(Bd_connection.connection.Employee.ToList());
            var log = Users.Where(a => a.Name.ToString() == txt_login.Text && a.Password.ToString() == txt_password.Password).FirstOrDefault();

            if (log != null)
            {
                NavigationService.Navigate(new Page_Log(log.Id_position.Value));
            }
            else
            {
                MessageBox.Show("Invalid user", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void comp_txt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ComboBox).SelectedItem as Company;
            compid = a.Id;
        }
    }
}
