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
    /// Interaction logic for Prod_add.xaml
    /// </summary>
    public partial class Prod_add : Page
    {
        public static ObservableCollection<Type_> Typ { get; set; }
        public static ObservableCollection<Company> Comp { get; set; }
        int i { get; set; }
        public Prod_add()
        {
            InitializeComponent();
            Typ = new ObservableCollection<Type_>(Bd_connection.connection.Type_.ToList());
            Comp = new ObservableCollection<Company>(Bd_connection.connection.Company.ToList());
            this.DataContext = this;
        }

        private void hall_txt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ComboBox).SelectedItem as Type_;
            i = a.Id;
        }

        private void add_event(object sender, RoutedEventArgs e)
        {
            var a = new Product
            {
                Name = name_txt.Text,
                Price = float.Parse(price_txt.Text),
                Type_id = i
            };
            var b = new ProductXCompany
            {
                Id_product = a.Id,
                Id_company = Page_Author.compid
            };
            Bd_connection.connection.Product.Add(a);
            Bd_connection.connection.ProductXCompany.Add(b);
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
