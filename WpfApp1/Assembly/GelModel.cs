using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Assembly
{


    class GelModel : Product
    {
        string selected_color;
        string selected_density;

        double selected_volume;


        List<string> avialable_density;
        List<double> avialable_volume;

        List<string> normal_density = new List<string>()
        {
            "Высокая", "Средняя"
        };

        List<string> sterile_density = new List<string>()
        {
            "Обычная"
        };

        List<double> noraml_volume = new List<double>() 
        {
            0.25, 1.0, 5.0
        };

        List<double> sterlie_volume = new List<double>()
        {
            0.015
        };


        List<MyPair<string, bool>> colors = new List<MyPair<string, bool>>()
        {
            new MyPair<string, bool>("Бесцветный",true),
            new MyPair<string, bool>( "Цветной",false ),
            new MyPair<string, bool>( "Стерильный",false ) 
        };

        public GelModel()
        {
            selected_color = colors[0].Key;

            avialable_density = normal_density;
            selected_density = avialable_density[0];

            avialable_volume = noraml_volume;
            selected_volume = avialable_volume[0];

            foreach (var e in colors)
            {
                e.PropertyChanged += Colors_PropertyChanged;
            }
        }



        public List<MyPair<string,bool>> Colors
        {
            get { return colors; }
        }


        public List<string> AvialableDensity
        {
            get { return avialable_density; }
        }

       

        public string SelectedDensity
        {
            get { return selected_density; }
            set { 
                selected_density = value; 
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(PriceUnit));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public List<double> AvialableVolume
        {
            get { return avialable_volume; }
        }

        public double SelectedVolume
        {
            get { return selected_volume; }
            set
            {
                selected_volume = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(PriceUnit));
            }
        }


        public override string Name
        {
            get
            {
                return $"Гель {selected_color}\nПлотн({selected_density})\n{selected_volume} кг.";
            }
        }


        List<KeyValuePair<List<object>, int>> prices = new List<KeyValuePair<List<object>, int>>()
        {
            new KeyValuePair<List<object>, int>(new List<object>(){"Стерильный","Обычный",0.015},100),
            new KeyValuePair<List<object>, int>(new List<object>(){"Цветной","Высокая",0.25},150),
            new KeyValuePair<List<object>, int>(new List<object>(){"Цветной","Высокая",1.0},210),
            new KeyValuePair<List<object>, int>(new List<object>(){"Цветной","Высокая",5.0},1050),

            new KeyValuePair<List<object>, int>(new List<object>(){"Цветной","Средняя",0.25},150),
            new KeyValuePair<List<object>, int>(new List<object>(){"Цветной","Средняя",1.0},250),
            new KeyValuePair<List<object>, int>(new List<object>(){"Цветной","Средняя",5.0},950),

            new KeyValuePair<List<object>, int>(new List<object>(){"Бесцветный","Средняя",0.25},120),
            new KeyValuePair<List<object>, int>(new List<object>(){"Бесцветный","Средняя",1.0},250),
            new KeyValuePair<List<object>, int>(new List<object>(){"Бесцветный","Средняя",5.0},1000),

            new KeyValuePair<List<object>, int>(new List<object>(){"Бесцветный","Высокая",0.25},120),
            new KeyValuePair<List<object>, int>(new List<object>(){"Бесцветный","Высокая",1.0},250),
            new KeyValuePair<List<object>, int>(new List<object>(){"Бесцветный","Высокая",5.0},1050),

        };

        public override int PriceUnit
        {
            get
            {
                int find_ind = 0;
                for(int i = 0; i < prices.Count; i++)
                {
                    if ((string)prices[i].Key[0] == selected_color)
                    {
                        find_ind = i;
                        break;
                    } 
                }

                for(int i=find_ind; i < prices.Count; i++)
                {
                    if((string)prices[i].Key[1] == selected_density)
                    {
                        find_ind = i; break;

                    }
                }

                for (int i = find_ind; i < prices.Count; i++)
                {
                    if ((double)prices[i].Key[2] == selected_volume)
                    {
                        find_ind = i;break;
                    }
                }

                price_unit = prices[find_ind].Value;
                OnPropertyChanged(nameof(TotalPrice));
                return prices[find_ind].Value;

            }
        }


        bool sterlie_pressed = false;
        private void Colors_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            
            MyPair<string,bool> t = (MyPair<string, bool>)sender;
            //Console.WriteLine($"Start {t.Key}");

            

            if (t.Value)
            {
                if(t.Key == "Стерильный")
                {
                    avialable_density = sterile_density;
                    avialable_volume = sterlie_volume;

                    selected_volume = avialable_volume[0];

                    selected_density = avialable_density[0];
                    sterlie_pressed = true;
                    OnPropertyChanged(nameof(SelectedDensity));
                    OnPropertyChanged(nameof(SelectedVolume));
                    OnPropertyChanged(nameof(PriceUnit));
                    OnPropertyChanged(nameof(TotalPrice));
                }
                else
                {
                    
                    avialable_density = normal_density;
                    if (sterlie_pressed)
                    {
                        avialable_volume = noraml_volume;
                        selected_volume = avialable_volume[0];
                        selected_density = avialable_density[0];
                        OnPropertyChanged(nameof(SelectedDensity));
                        OnPropertyChanged(nameof(SelectedVolume));
                        OnPropertyChanged(nameof(PriceUnit));
                        OnPropertyChanged(nameof(TotalPrice));
                        sterlie_pressed = false;
                    }
                }



                selected_color = t.Key;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(AvialableDensity));
                OnPropertyChanged(nameof(AvialableVolume));
                OnPropertyChanged(nameof(PriceUnit));
                OnPropertyChanged(nameof(TotalPrice));
            }

        }

        



    }
}

