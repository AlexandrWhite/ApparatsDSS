using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WpfApp1.Assembly;


namespace WpfApp1
{
    class AssemblyVM : INotifyPropertyChanged
    {

        public RelayCommand<UIElement> ShowCommand { get; private set; }
        public RelayCommand<UIElement> HideCommand { get; private set; }
        public RelayCommand<string> AddProductCommand { get; private set; }
        public RelayCommand<Product> RemoveProductCommand { get; private set; }
        public RelayCommand CreateDocumentCommand { get; private set; }


        Random r = new Random();
        ObservableCollection<Product> products = new ObservableCollection<Product>();
        

        public AssemblyVM()
        {

            //NavigationService ns = NavigationService.GetNavigationService(this);
            //ns.Navigate(new System.Uri("MenuWindow.xaml", UriKind.RelativeOrAbsolute));

    
            ShowCommand = new RelayCommand<UIElement>((param) =>
            {
                param.Visibility = Visibility.Visible;
            });

            HideCommand = new RelayCommand<UIElement>((param) =>
            {
                param.Visibility = Visibility.Collapsed;
            });

            AddProductCommand = new RelayCommand<string>((param) =>
            {
                addProduct(param);
            });

            RemoveProductCommand = new RelayCommand<Product>((param) =>
            {
                Console.WriteLine("Remove");
                Console.WriteLine(param);
                products.Remove(param);
                OnPropertyChanged(nameof(param));
                OnPropertyChanged(nameof(TotalSum));
            });

            CreateDocumentCommand = new RelayCommand(() =>
            {
                Console.WriteLine("I will save your file");
                Stream myStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "Документ Word (*.docx) |*.docx|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == true)
                {
                    myStream = saveFileDialog1.OpenFile();
                    myStream.Close();
                    Console.WriteLine($"I will write {saveFileDialog1.FileName}");                   
                }
                ProductDocumentWord pd = new ProductDocumentWord(saveFileDialog1.FileName);
                pd.Process(products);
            });

        }


        private void addProduct(string name)
        {
            Product p;
            
            switch (name)
            {
                case "Гель":
                    p = new GelModel();
                    p.View = new GelView();
                    break;

                case "Перчатки":
                    p = new GlovesModel();
                    p.View = new GlovesView();
                    break;

                case "Бак для отходов":
                    p = new BasketModel(name, r.Next(1000, 100000));
                    p.View = new BasketView();
                    break;

                case "Фотобумага":
                    p = new PhotoModel();
                    p.View = new PhotoView();
                    break;

                default:
                    p = new Product("Презервативы (1 пачка 100 шт.)",780);
                    //p.PropertyChanged += Product_PropertyChanged;
                    break;
                
            }
            products.Add(p);
            p.PropertyChanged += Product_PropertyChanged;
            OnPropertyChanged(nameof(Products));
            OnPropertyChanged(nameof(TotalSum));
        }

        private void Product_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
           

            if (e.PropertyName == "TotalPrice")
            {
                Console.WriteLine($"changed {e.PropertyName}");
                OnPropertyChanged(nameof(TotalSum));
            }
            
        }

        public ObservableCollection<Product> Products
        {
            get { return products; }
        }

        public decimal TotalSum
        {
            get 
            {
                decimal sum = 0;
                foreach(var p in Products)
                    sum += p.TotalPrice;
                Console.WriteLine(sum);
                return sum;
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
