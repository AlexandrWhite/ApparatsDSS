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
           


            foreach (var element in using_fields_data)
            {
                search_result.Add(element);
                element.PropertyChanged += FieldsElementPropertyChanged;
            }


            foreach(var element in countries_data)
            {
                element.PropertyChanged += CountriesPropertyChanged;
            }

            foreach (var element in construction)
            {
                element.PropertyChanged += Constructions_PropertyChanged;
            }

        }

        private void Constructions_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Res));
        }

        private void CountriesPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            MyPair<string, bool> element = sender as MyPair<string, bool>;

            if (element.Value && selected_countries.Find(s => s == element.Key) is null)
                selected_countries.Add(element.Key);
            else if (element.Value == false)
                selected_countries.Remove(element.Key);
            OnPropertyChanged(nameof(Res));
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


        //float monitor_diag;
        string monitor_diag="0";
        public string MonitorDiag
        {
            get { return monitor_diag; }
            set {
                monitor_diag = value;
                OnPropertyChanged(nameof(Res)); }
        }

        string mass = "0";
        public string Mass
        {
            get { return mass; }
            set
            {
                mass = value;
                OnPropertyChanged(nameof(Res));
            }
        }

        string min_height = "0";
        public string MinHeight
        {
            get { return min_height; }
            set { 
                min_height = value;
                OnPropertyChanged(nameof(Res));
            }
        }


        string min_width = "0";
        public string MinWidth
        {
            get { return min_width; }
            set
            {
                min_width = value;
                OnPropertyChanged(nameof(Res));
            }
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
            new MyPair<string, bool>( "Исследование сонной артерии", false)
        };

        private ObservableCollection<MyPair<string, bool>> sensors_data = new ObservableCollection<MyPair<string, bool>>()
        {
            new MyPair<string, bool>("Биопсийный",false),
            new MyPair<string, bool>("Биплановый",false),
            new MyPair<string, bool>("Внутриполостной",false),

            new MyPair<string, bool>("Высокоплотный",false),
            new MyPair<string, bool>("Доплеровский",false),
            new MyPair<string, bool>("Интераоперационный",false),

            new MyPair<string, bool>("Карандашный",false),
            new MyPair<string, bool>("Конвексный",false),
            new MyPair<string, bool>("Лапароскопический",false),

            new MyPair<string, bool>("Линейный",false),
            new MyPair<string, bool>("Матричный",false),
            new MyPair<string, bool>("Микроконвексный",false),

            new MyPair<string, bool>("Объемный",false),
            new MyPair<string, bool>("Секторный",false),
            new MyPair<string, bool>("Секторный фазированный",false),

            new MyPair<string, bool>("Фазированный",false),
            new MyPair<string, bool>("Чреспищеводный",false)

        };


        List<string> selected_countries = new List<string>();
        private ObservableCollection<MyPair<string, bool>> countries_data = new ObservableCollection<MyPair<string, bool>>()
        {
            new MyPair<string, bool>( "Германия", false),
            new MyPair<string, bool>( "Дания", false),
            new MyPair<string, bool>( "Италия", false),
            new MyPair<string, bool>( "Китай", false),
            new MyPair<string, bool>( "Недерланды", false),
            new MyPair<string, bool>( "Республика Корея", false),
            new MyPair<string, bool>( "Россия", false),
            new MyPair<string, bool>( "США", false),
            new MyPair<string, bool>( "Франция", false),
            new MyPair<string, bool>( "Япония", false)
        }; 

        public ObservableCollection<MyPair<string,bool>> Countries
        {
            get
            {
                return countries_data;
            }
            set
            {
                countries_data = value;
            }
        }


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



        int selected_price_index = 0;

        public int SelectedPriceIndex
        {
            get { return selected_price_index; }
            set { selected_price_index = value; OnPropertyChanged(nameof(Res)); }
        }

        List<string> prices = new List<string>()
        {
            "До 800 000 рублей",
            "От 800 000 рублей до 1 500 000 рублей",
            "От 1 500 000 рублей до 2 000 000 рублей",
            "От 2 000 000 рублей до 3 000 000 рублей",
            "От 3 000 000 и выше",
        };


        int selected_class_index = 0;
        public int SelectedClassIndex
        {
            get { return selected_class_index; }
            set { selected_class_index = value; OnPropertyChanged(nameof(Res)); }
        }

        List<string> apparatClasses = new List<string>()
        {
            "Базовый",
            "Средний",
            "Высокий",
            "Премиальный",
            "Экспертный"
        };


        List<MyPair<string,bool>> construction = new List<MyPair<string,bool>>()
        {
             new MyPair<string, bool>( "Стационарный", true),
             new MyPair<string, bool>( "Портативный", false)
        };

        public List<MyPair<string, bool>> Constructions
        {
            get { return construction; }
            set { construction = value; }
        }

        bool have_rus_instruction = true;
        public bool HaveRusInstruction
        {
            get { return have_rus_instruction; }
            set { 
                have_rus_instruction = value;
                OnPropertyChanged(nameof(Res));
            }
        }


        public string Res
        {
            get {
                
                string res = "";
                res = "Области применения:\n";
                foreach(string field in selected_fields)
                {
                    res += field + "\n";
                }

                res += "\n";
                res += "Класс препарата:\n";
                res += apparatClasses[selected_class_index] +"\n";

                res += "\n";

                res += "\n";
                res += "Диагональ монитора:\n";
                res += float.Parse(MonitorDiag).ToString() + "\n";
                res += "\n";

                res += "\n";
                res += "Цена:\n";
                res += prices[selected_price_index] + "\n";
                res += "\n";

                res += "Страны:\n";
                foreach (string country in selected_countries)
                {
                    res += country + "\n";
                }
                res += "\n";

                res += "Конструкционное исполнение:\n";
                foreach (MyPair<string,bool> constr in Constructions)
                {
                    if (constr.Value)
                    {
                        res += constr.Key+"\n";
                    }                    
                }
                res += "\n";

                res += "Инструкция на русском:\n";
                res += HaveRusInstruction.ToString()+"\n";
                res += "\n";



                res += "Масса:\n";
                res += Double.Parse(Mass).ToString() + "\n";
                res += "\n";

                res += "Высота:\n";
                res += Double.Parse(MinHeight).ToString() + "\n";
                res += "\n";

                res += "Ширина:\n";
                res += Double.Parse(MinWidth).ToString() + "\n";
                res += "\n";

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
