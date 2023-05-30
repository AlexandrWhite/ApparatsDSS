using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Assembly;


namespace WpfApp1
{
    class AssemblyVM : INotifyPropertyChanged
    {

        public RelayCommand<UIElement> ShowCommand { get; private set; }
        public RelayCommand<UIElement> HideCommand { get; private set; }

        public AssemblyVM()
        {
            ShowCommand = new RelayCommand<UIElement>((param) =>
            {
                param.Visibility = Visibility.Visible;
            });

            HideCommand = new RelayCommand<UIElement>((param) =>
            {
                param.Visibility = Visibility.Collapsed;
            });
        }


        List<Product> products = new List<Product>();
        decimal total_sum = 0;

        public List<Product> Products
        {
            get { return products; }
        }

        public decimal TotalSum
        {
            get { return total_sum; }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
