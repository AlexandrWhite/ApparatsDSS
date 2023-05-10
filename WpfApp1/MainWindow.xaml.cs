﻿using HandyControl.Tools;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Page
    {
        public MainWindow()
        {
            InitializeComponent();
            ConfigHelper.Instance.SetLang("ru");         



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //AssemblyWindow aw = new AssemblyWindow();
            //aw.Show();
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new System.Uri("MenuWindow.xaml", UriKind.RelativeOrAbsolute));
            //MenuWindow mw = new MenuWindow();
            //Content = mw.Content;

        }
    }
}
