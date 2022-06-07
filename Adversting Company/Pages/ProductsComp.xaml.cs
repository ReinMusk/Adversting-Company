using Adversting_Company.dbo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Adversting_Company
{
    /// <summary>
    /// Interaction logic for ProductsComp.xaml
    /// </summary>
    public partial class ProductsComp : Page
    {
        public static ObservableCollection<ProductXCompany> x { get; set; }
        public static ObservableCollection<Product> prod { get; set; }
        public static ObservableCollection<Company> Comp { get; set; }
        public static ObservableCollection<Type_> typ { get; set; }
        public static int i { get; set; }

        public static IEnumerable<Product> result { get; set; }
        public ProductsComp()
        {
            InitializeComponent();

            x = new ObservableCollection<ProductXCompany>(Bd_connection.connection.ProductXCompany);
            prod = new ObservableCollection<Product>(Bd_connection.connection.Product);
            Comp = new ObservableCollection<Company>(Bd_connection.connection.Company.ToList());
            typ = new ObservableCollection<Type_>(Bd_connection.connection.Type_);

            result = from x in x where x.Id_company == i 
                         join t in prod on x.Id_product equals t.Id
                         select new Product { Name = t.Name, Price = t.Price.Value};

            this.DataContext = this;
        }

        private void comp_txt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ComboBox).SelectedItem as Company;
            i = a.Id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in result)
                txt.Text += $"{item.Name} - {item.Price} \n";
            
        }
    }
}
