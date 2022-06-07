using Adversting_Company.dbo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace Adversting_Company
{
    /// <summary>
    /// Interaction logic for Refresh_List.xaml
    /// </summary>
    public partial class Refresh_List : Page
    {
        public static ObservableCollection<Product> prod { get; set; }
        public Refresh_List()
        {
            InitializeComponent();
            prod = new ObservableCollection<Product>(Bd_connection.connection.Product.ToList());
            this.DataContext = this;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ListView).SelectedItem as Product;

            RefPrice win = new RefPrice(a);
            win.Show();
        }
    }
}
