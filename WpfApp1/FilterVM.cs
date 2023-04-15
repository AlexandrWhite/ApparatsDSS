using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp1
{
    class FilterVM:INotifyPropertyChanged
    {
        public RelayCommand<string> SearchCommand { get; }
        public RelayCommand SelectAllCommand { get; }
        public RelayCommand DeselectAllCommand { get;  }



        List<string> selected_fields = new List<string>();


        ObservableCollection<MyPair<string, bool>> search_result = new ObservableCollection<MyPair<string, bool>>();

        public FilterVM()
        {            
            SearchCommand = new RelayCommand<string>(Search);
            SelectAllCommand = new RelayCommand(SelectAll);
            DeselectAllCommand = new RelayCommand(DeselectAll);
            SearchResult.CollectionChanged += SearchResult_CollectionChanged;


            foreach (var element in using_fields_data)
            {
                search_result.Add(element);
                element.PropertyChanged += FieldsElementPropertyChanged;
            }
            
            
        }

        private void FieldsElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            MyPair<string, bool> element = sender as MyPair<string, bool>;
            
            if (element.Value && selected_fields.Find(s => s == element.Key) is null)
                selected_fields.Add(element.Key);
            else if (element.Value == false)
                selected_fields.Remove(element.Key);
            OnPropertyChanged(nameof(Res));
        }

        private void SearchResult_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //Console.WriteLine(sender);
        }

        private void SelectAll()
        {        
            foreach (var element in SearchResult)
                element.Value = true;         
            OnPropertyChanged(nameof(SearchResult));
            OnPropertyChanged(nameof(Res));
        }

        private void DeselectAll()
        {
            foreach (var element in SearchResult)            
                element.Value = false;            
            OnPropertyChanged(nameof(SearchResult));
            OnPropertyChanged(nameof(Res));
        }





        private void Search(string query)
        {           
            query = query.ToLower();
            SearchResult.Clear();

            var find_list = using_fields_data.Where(s => s.Key.ToLower().Contains(query));


            if (find_list is not null) {
                foreach (var element in find_list)
                {
                    SearchResult.Add(element);
                }             
                OnPropertyChanged(nameof(SearchResult));
            }
        }

        private ObservableCollection<MyPair<string, bool>> using_fields_data = new ObservableCollection<MyPair<string, bool>>() 
        {
            new MyPair<string, bool>( "Абдоминальные исследования", false),
            new MyPair<string, bool>( "Внутриполостные исследования", false),
            new MyPair<string, bool>( "Гастроэнтерология", false),
            new MyPair<string, bool>( "Интраоперационные исследования", false),
            new MyPair<string, bool>( "Исследования малых органов", false),
            new MyPair<string, bool>( "Исследования молочной железы", false),
            new MyPair<string, bool>( "Исследования мочевого пузыря", false),
            new MyPair<string, bool>( "Исследование опорно-двигательной системы", false),
            new MyPair<string, bool>( "Исследование органов брюшной полости", false),
            new MyPair<string, bool>( "Исследование поверхностных органов", false),
            new MyPair<string, bool>( "Исследование поверхностных структур", false),
            new MyPair<string, bool>( "Исследование предстательной железы", false),
            new MyPair<string, bool>( "Исследование сонной артерии", false),
        };

        public ObservableCollection<MyPair<string, bool>> SearchResult
        {
            get { return search_result; }
            set
            {
                if (search_result != value)
                {
                    search_result = value;                    
                    OnPropertyChanged(nameof(SearchResult));
                }
            }
        }       


        List<string> prices = new List<string>()
        {
            "До 800 000 рублей",
            "От 800 000 рублей до 1 500 000 рублей",
            "От 1 500 000 рублей до 2 000 000 рублей",
            "От 2 000 000 рублей до 3 000 000 рублей",
            "От 3 000 000 и выше",
        };

        List<string> apparatClasses = new List<string>()
        {
            "Базовый",
            "Средний",
            "Высокий",
            "Премиальный",
            "Экспертный"
        };

      
        public string Res
        {
            get {
                Console.WriteLine("inResultUPd!!!!");
                string res = "";
                res = "Области применения:\n";
                foreach(string field in selected_fields)
                {
                    res += field + "\n";
                }
                return res;
            }
        }

        public List<string> ApparatClasses
        {
            get { return apparatClasses; }
        }


        public List<string> Prices
        {
            get { return prices; }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }


    public class MyPair<T1, T2>:INotifyPropertyChanged
    {
        T1 _key;
        T2 _val;
        
        public T1 Key
        {
            get { return _key; }
            set { _key = value; OnPropertyChanged(nameof(Key)); }
        }

        public T2 Value 
        {
            get { return _val; }
            set { _val = value; OnPropertyChanged(nameof(Value)); }
        }

        public MyPair(T1 key, T2 value)
        {
            Key = key;
            Value = value;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
