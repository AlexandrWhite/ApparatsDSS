using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.Assembly
{
    class Product:INotifyPropertyChanged
    {
        protected string name;
        int count = 1;
        protected int price_unit;

        UserControl view;


        public Product(string name, int price_unit)
        {
            this.name = name;
            this.price_unit = price_unit;
            
        }

        public Product()
        {
            
        }

        public virtual string Name
        {
            get { return name; }
        }

        public int Count
        {
            set { count = value; OnPropertyChanged(nameof(TotalPrice)); }
            get { return count; }
        }

        public virtual int PriceUnit
        {
            get { return price_unit; }
            
        }

        public UserControl View 
        {
            get
            {
                return view;
            }
            set
            {
                view = value;
                view.DataContext = this;
            }
        }

        public int TotalPrice
        {
            get { return count*price_unit; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
