using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Adversting_Company
{
    /// <summary>
    /// Interaction logic for Page_Log.xaml
    /// </summary>
    public partial class Page_Log : Page
    {
        public static int pos;
        public Page_Log(int Position)
        {
            InitializeComponent();
            pos = Position;

            if (pos == 3)
            {
                adT.Visibility = Visibility.Hidden;
                adEm.Visibility = Visibility.Hidden;
                RefList.Visibility = Visibility.Hidden;
                delE.Visibility = Visibility.Hidden;
                adCom.Visibility = Visibility.Hidden;
            }
            if (pos == 2)
            {
                adCom.Visibility = Visibility.Hidden;
            }
            if (pos == 1)
            {
                adT.Visibility = Visibility.Hidden;
                RefList.Visibility = Visibility.Hidden;
            }
        }


        private void List_prod(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductsComp());
        }

        private void List_allComp(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllCompanyList());
        }

        private void Add_prod(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Prod_add());
        }

        private void Add_Empl(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Empl_Add());
        }

        private void Refresh_List(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Refresh_List());
        }

        private void Del_Empl(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Empl_Del());
        }

        private void Add_Comp(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Add_Company());
        }
    }
}
