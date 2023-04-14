using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


        ObservableCollection<MyPair<string, bool>> search_result = new ObservableCollection<MyPair<string, bool>>();

        public FilterVM()
        {            
            SearchCommand = new RelayCommand<string>(Search);
            foreach(var element in using_fields_data)
            {
                search_result.Add(element);
            }
            
        }

       

       

        private void Search(string query)
        {
            query = query.ToLower();
            SearchResult.Clear();

            //Console.WriteLine(using_fields_data.Count);
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







        List<string> names_data = new List<string>(){
            "Абдоминальные исследования",
            "Акушерство и гинекология",
            "Внутриполостные исследования",
            "Гастроэнтерология",
            
            "Исследование малых органов",
            "Исследование молочной железы",
            "Исследование мочевого пузыря",
            "Исследование опорно-двигательной системы",
            "Исследование органов брюшной полости",
            "Исследование поверхностных органов",
            "Исследование поверхностных структур",
            "Исследование почек",
            "Исследование предстательной железы",
            "Исследование сонной артерии",


             "Исследование мочевого пузыря",
            "Исследование опорно-двигательной системы",
            "Исследование органов брюшной полости",
            "Исследование поверхностных органов",
            "Исследование поверхностных структур",
            "Исследование почек",
            "Исследование предстательной железы",
            "Исследование сонной артерии",

            "Исследование мочевого пузыря",
            "Исследование опорно-двигательной системы",
            "Исследование органов брюшной полости",
            "Исследование поверхностных органов",
            "Исследование поверхностных структур",
            "Исследование почек",
            "Исследование предстательной железы",
            "Исследование сонной артерии",
            "Исследование мочевого пузыря",
            "Исследование опорно-двигательной системы",
            "Исследование органов брюшной полости",
            "Исследование поверхностных органов",
            "Исследование поверхностных структур",
            "Исследование почек",
            "Исследование предстательной железы",
            "Исследование сонной артерии",
            "Исследование мочевого пузыря",
            "Исследование опорно-двигательной системы",
            "Исследование органов брюшной полости",
            "Исследование поверхностных органов",
            "Исследование поверхностных структур",
            "Исследование почек",
            "Исследование предстательной железы",
            "Исследование сонной артерии"
        };

        List<string> fields = new List<string>();

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

      

        public List<string> ApparatClasses
        {
            get { return apparatClasses; }
        }

        public List<String> Names
        {
            get { return fields; }
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


    public class MyPair<T1, T2>
    {
        public T1 Key { get; set; }
        public T2 Value { get; set; }

        public MyPair(T1 key, T2 value)
        {
            Key = key;
            Value = value;
        }
    }


}
