﻿using System;
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
using WpfApp1.Assembly;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AssemblyWindow.xaml
    /// </summary>
    public partial class AssemblyWindow : Page
    {
        
        public AssemblyWindow()
        {
            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new System.Uri("MenuWindow.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
