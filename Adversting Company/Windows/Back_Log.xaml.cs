using System;
using System.Windows;


namespace Adversting_Company
{
    /// <summary>
    /// Interaction logic for Back_Log.xaml
    /// </summary>
    public partial class Back_Log : Window
    {
        public Back_Log()
        {
            InitializeComponent();
            Log_frame.NavigationService.Navigate(new Page_Author());
        }
    }
}
