using GalaSoft.MvvmLight.Command;
using MongoDB.Bson;
using MongoDB.Driver;
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
        Dictionary<string, FilterDefinition<Apparat>> filters = new Dictionary<string, FilterDefinition<Apparat>>();

        public List<Apparat> TestData
        {
            get 
            {
              
                var mainFilter = Builders<Apparat>.Filter.Empty;
                foreach (var element in filters)
                    mainFilter &= element.Value;

                var collection = ApparatDB.MongoClient.GetDatabase("test").GetCollection<Apparat>("apparats").Find(mainFilter).ToList();
                return collection;
            }
        }


        public FilterVM()
        {
            //apm.show_apparats();

            foreach (var element in using_fields_data)             
                element.PropertyChanged += FieldsElementPropertyChanged;

            foreach (var element in countries_data)
                element.PropertyChanged += CountriesPropertyChanged;

            foreach (var element in construction)
                element.PropertyChanged += Constructions_PropertyChanged;

            foreach(var element in sensors_data)
                element.PropertyChanged += Sensors_PropertyChanged;

        }
                

        private void Sensors_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var selected_sensors = sensors_data.FindAll(item => item.Value == true).Select(item => item.Key).ToList();
            var filter = Builders<Apparat>.Filter.All("Набор ультразвуковых датчиков", selected_sensors);

            
            if (selected_sensors.Count == 0)
                filters["Набор ультразвуковых датчиков"] = Builders<Apparat>.Filter.Empty;
            else
                filters["Набор ультразвуковых датчиков"] = filter;
            OnPropertyChanged(nameof(TestData));
        }

        private void Constructions_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var selected_constructions = construction.FindAll(item => item.Value == true).Select(item => item.Key)
                .Select(item => item.ToLower()).ToList();

            foreach(var s in selected_constructions)
            {
                Console.WriteLine(s);
            }

            var filter = Builders<Apparat>.Filter.In("Конструктивное исполнение", selected_constructions);
            if (selected_constructions.Count == 0)
                filters["Конструктивное исполнение"] = Builders<Apparat>.Filter.Empty;
            else
                filters["Конструктивное исполнение"] = filter;
            OnPropertyChanged(nameof(TestData));
        }


        
        private void CountriesPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var selected_countries = Countries.FindAll(item => item.Value == true).Select(item => item.Key).ToList();
            var filter = Builders<Apparat>.Filter.In("Страна производства", selected_countries);

            if (selected_countries.Count == 0)
                filters["Страна производства"] = Builders<Apparat>.Filter.Empty;
            else
                filters["Страна производства"] = filter;

            OnPropertyChanged(nameof(TestData));  
        }

        private void FieldsElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var selected_fields = using_fields_data.FindAll(item => item.Value == true).Select(item => item.Key).ToList();
            var filter = Builders<Apparat>.Filter.All("Области применения", selected_fields);


            if (selected_fields.Count == 0)
                filters["Области применения"] = Builders<Apparat>.Filter.Empty;
            else
                filters["Области применения"] = filter;
            OnPropertyChanged(nameof(TestData));

        }     

        //float monitor_diag;
        int monitor_diag=0;
        public int MonitorDiag
        {
            get { return monitor_diag; }
            set {
                monitor_diag = value;
                filters["Диагональ ЖК-монитора (в дюймах)"] = Builders<Apparat>.Filter.Lte("Диагональ ЖК-монитора (в дюймах)",
                    monitor_diag);
                OnPropertyChanged(nameof(TestData)); }
        }

        int mass = 0;
        public int Mass
        {
            get { return mass; }
            set
            {
                mass = value;
                
                filters["Масса (кг)"] = Builders<Apparat>.Filter.Lte("Масса (кг)", mass);
                //OnPropertyChanged(nameof(Res));
                OnPropertyChanged(nameof(TestData));
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


        string width = "0";
        public string Width
        {
            get { return width; }
            set
            {
                width = value;

                

                OnPropertyChanged(nameof(Res));
            }
        }



        private List<MyPair<string, bool>> using_fields_data = new List<MyPair<string, bool>>() 
        {
            new MyPair<string, bool>( "Абдоминальные исследования", false),
            new MyPair<string, bool>( "Акушерство и гинекология", false),
            new MyPair<string, bool>( "Ангиология", false),
            new MyPair<string, bool>( "Биопсия", false),
            new MyPair<string, bool>( "Внутриполостные исследования", false),
            new MyPair<string, bool>( "Гастроэнтерология", false),
            new MyPair<string, bool>( "Интраоперационные исследования", false),
            new MyPair<string, bool>( "Исследование малых органов", false),
            new MyPair<string, bool>( "Исследование молочной железы", false),
            new MyPair<string, bool>( "Исследование мочевого пузыря", false),
            new MyPair<string, bool>( "Исследование опорно-двигательной системы", false),
            new MyPair<string, bool>( "Исследование органов брюшной полости", false),
            new MyPair<string, bool>( "Исследование поверхностных органов", false),
            new MyPair<string, bool>( "Исследование поверхностных структур", false),
            new MyPair<string, bool>( "Исследование почек", false),
            new MyPair<string, bool>( "Исследование предстательной железы", false),
            new MyPair<string, bool>( "Исследование сонной артерии", false),
            new MyPair<string, bool>( "Исследование сосудов", false),
            new MyPair<string, bool>( "Исследование щитовидной железы", false),
            new MyPair<string, bool>( "Кардиология", false),
            new MyPair<string, bool>( "Лапароскопия", false),
            new MyPair<string, bool>( "Маммология", false),
            new MyPair<string, bool>( "Неврология", false),
            new MyPair<string, bool>( "Нейросонография", false),
            new MyPair<string, bool>( "Неонатология", false),
            new MyPair<string, bool>( "Нефрология", false),
            new MyPair<string, bool>( "Общие исследования", false),
            new MyPair<string, bool>( "Онкология", false),
            new MyPair<string, bool>( "Ортопедия", false),
            new MyPair<string, bool>( "Офтальмология", false),
            new MyPair<string, bool>( "Педиатрия", false),
            new MyPair<string, bool>( "Рентгенология", false),
            new MyPair<string, bool>( "Травматология", false),
            new MyPair<string, bool>( "Транскраниальные исследования", false),
            new MyPair<string, bool>( "Урология", false),
            new MyPair<string, bool>( "Хирургия", false),
            new MyPair<string, bool>( "Чреспищеводные исследования", false),
            new MyPair<string, bool>( "Эластография", false),
            new MyPair<string, bool>( "Эндокринология", false),
            new MyPair<string, bool>( "Эндоскопия", false),
            new MyPair<string, bool>( "Эхокардиография", false)
        };

        private List<MyPair<string, bool>> countries_data = new List<MyPair<string, bool>>()
        {
            new MyPair<string, bool>( "Германия", false),
            new MyPair<string, bool>( "Дания", false),
            new MyPair<string, bool>( "Италия", false),
            new MyPair<string, bool>( "Китай", false),
            new MyPair<string, bool>( "Нидерланды", false),
            new MyPair<string, bool>( "Республика Корея", false),
            new MyPair<string, bool>( "Россия", false),
            new MyPair<string, bool>( "США", false),
            new MyPair<string, bool>( "Франция", false),
            new MyPair<string, bool>( "Япония", false)
        };

        public List<MyPair<string, bool>> UsingFieldsData
        {
            get { return using_fields_data; }
        }

      

        private List<MyPair<string, bool>> sensors_data = new List<MyPair<string, bool>>()
        {
            new MyPair<string, bool>("Биопсийный",false),
            new MyPair<string, bool>("Биплановый",false),
            new MyPair<string, bool>("Внутриполостной",false),

            new MyPair<string, bool>("Высокоплотный",false),
            new MyPair<string, bool>("Доплеровский",false),
            new MyPair<string, bool>("Интраоперационный",false),

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

        public List<MyPair<string, bool>> SensorsData
        {
            get { return sensors_data; }
        }


        
       

        public List<MyPair<string,bool>> Countries
        {
            get
            {
                return countries_data;
            }           
        }






        int selected_price_index = 0;

        public int SelectedPriceIndex
        {
            get { return selected_price_index; }
            set {
                
                selected_price_index = value; 
                if (selected_price_index == 0)
                    filters["Цена (руб)"] = Builders<Apparat>.Filter.Lte("Цена (руб)", price_ranges[selected_price_index]);
                else if (selected_price_index == price_ranges.Length) 
                    filters["Цена (руб)"] = Builders<Apparat>.Filter.Gte("Цена (руб)", price_ranges[selected_price_index-1]);
                else
                {
                    filters["Цена (руб)"] = Builders<Apparat>.Filter.And(Builders<Apparat>.Filter.Lte("Цена (руб)", price_ranges[selected_price_index]),
                        Builders<Apparat>.Filter.Gte("Цена (руб)", price_ranges[selected_price_index-1]));
                }
                OnPropertyChanged(nameof(Res));
                OnPropertyChanged(nameof(TestData));
            }
        }

        double[] price_ranges = { 8*1e5, 1.5*1e6, 2*1e6, 3*1e6};

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
            "Любой",
            "Базовый",
            "Средний",
            "Высокий",
            "Премиальный",
            "Экспертный"
        };


        List<MyPair<string,bool>> construction = new List<MyPair<string,bool>>()
        {
             new MyPair<string, bool>( "Стационарный", false),
             new MyPair<string, bool>( "Портативный", false)
        };

        public List<MyPair<string, bool>> Constructions
        {
            get { return construction; }
            set { construction = value; }
        }

        bool have_rus_instruction = false;
        public bool HaveRusInstruction
        {
            get { return have_rus_instruction; }
            set {
                if (value)
                    filters["Руководство по эксплуатации на русском"] =
                        Builders<Apparat>.Filter.Eq("Руководство по эксплуатации на русском", value);
                else
                    filters["Руководство по эксплуатации на русском"] = Builders<Apparat>.Filter.Empty;
               
                have_rus_instruction = value;
                OnPropertyChanged(nameof(TestData));
            }
        }

      
        public string Res
        {
            get {
                
                string res = "";
                //res = "Области применения:\n";
                //foreach(string field in selected_fields)
                //{
                //    res += field + "\n";
                //}

                res += "\n";



                //res += "Набор датчиков:\n";
                //foreach (string sensor in selected_sensors)
                //{
                //    res += sensor + "\n";
                //}

                res += "\n";



                res += "Класс препарата:\n";
                res += apparatClasses[selected_class_index] +"\n";

                res += "\n";

                //res += "\n";
                //res += "Диагональ монитора:\n";
                //res += float.Parse(MonitorDiag).ToString() + "\n";
                //res += "\n";

                res += "\n";
                res += "Цена:\n";
                res += prices[selected_price_index] + "\n";
                res += "\n";

                //res += "Страны:\n";
                //foreach (string country in selected_countries)
                //{
                //    res += country + "\n";
                //}
                //res += "\n";

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



                //res += "Масса:\n";
                //res += Double.Parse(Mass).ToString() + "\n";
                //res += "\n";

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
