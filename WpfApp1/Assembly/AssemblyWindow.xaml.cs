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
using System.Windows.Shapes;
using WpfApp1.Assembly;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AssemblyWindow.xaml
    /// </summary>
    public partial class AssemblyWindow : Window
    {
        ChoiceProduct cp;
        public AssemblyWindow()
        {
            InitializeComponent();
            cp = new ChoiceProduct();
            cp.Visibility = Visibility.Collapsed;
            MainGrid.Children.Add(cp);
            Grid.SetRowSpan(cp, 2);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cp.Visibility = Visibility.Visible;
        }
    }
}
