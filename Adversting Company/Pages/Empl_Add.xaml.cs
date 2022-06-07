using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Collections.ObjectModel;
using Adversting_Company.dbo;

namespace Adversting_Company
{
    /// <summary>
    /// Interaction logic for Empl_Add.xaml
    /// </summary>
    public partial class Empl_Add : Page
    {
        public static ObservableCollection<Position> Pos { get; set; }
        public static ObservableCollection<Employee> Employees { get; set; }
        int i { get; set; }
        public Empl_Add()
        {
            InitializeComponent();
            Pos = new ObservableCollection<Position>(Bd_connection.connection.Position.ToList());
            Employees = new ObservableCollection<Employee>(Bd_connection.connection.Employee.ToList());
            this.DataContext = this;
        }

        private void position_txt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ComboBox).SelectedItem as Position;
            i = a.Id;
        }

        private void registation_event(object sender, RoutedEventArgs e)
        {
            if (name_txt.Text == "" || password_txt.Text == "")
            {
                MessageBox.Show($"Вы что то не заполнили", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var a = new Employee
                {
                    Name = name_txt.Text,
                    Surname = secondN_txt.Text,
                    Patronymic = password_txt.Text,
                    Password = password_txt.Text,
                    Number = number_txt.Text,
                    Id_position = i
                };
                Bd_connection.connection.Employee.Add(a);
                Bd_connection.connection.SaveChanges();
                MessageBox.Show("OK");
                NavigationService.Navigate(new Page_Log(Page_Log.pos));
            }
        }

        private void reverse_event(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page_Log(Page_Log.pos));
        }
    }
}
