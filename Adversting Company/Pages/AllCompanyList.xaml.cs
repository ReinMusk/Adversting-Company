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
    /// Interaction logic for AllCompanyList.xaml
    /// </summary>
    public partial class AllCompanyList : Page
    {
        public static ObservableCollection<Company> Comp { get; set; }
        public AllCompanyList()
        {
            InitializeComponent();
            Comp = new ObservableCollection<Company>(Bd_connection.connection.Company.ToList());
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page_Log(Page_Log.pos));
        }
    }
}
