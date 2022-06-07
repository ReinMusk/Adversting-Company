using Adversting_Company.dbo;
using System;
using System.Collections.ObjectModel;
using System.Windows;


namespace Adversting_Company
{
    /// <summary>
    /// Interaction logic for RefPrice.xaml
    /// </summary>
    public partial class RefPrice : Window
    {
        public static ObservableCollection<Product> prod { get; set; }
        public static Product ac;
        public RefPrice(Product a)
        {
            InitializeComponent();
            prod = new ObservableCollection<Product>(Bd_connection.connection.Product);

            ac = a;
            vus.Text = a.Name;
        }
        private void Btn_buy_Click(object sender, RoutedEventArgs e)
        {
            ac.Price = Convert.ToDouble(price_txt.Text);

            Bd_connection.connection.SaveChanges();
            this.Close();
        }
    }
}
