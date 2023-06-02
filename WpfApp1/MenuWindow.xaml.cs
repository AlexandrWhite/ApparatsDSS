using System;
using System.Collections.Generic;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Page
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow mw = new MainWindow();

            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new System.Uri("MainWindow.xaml", UriKind.RelativeOrAbsolute));
            //Content = mw.Content;
            //mw.DataContext = new FilterVM();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new System.Uri("RecomendationPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new System.Uri("HelpPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //AssemblyWindow aw = new AssemblyWindow();
            //aw.Show();
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new System.Uri("Assembly/AssemblyWindow.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
