using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Логика взаимодействия для SearchAndCheckboxControl.xaml
    /// </summary>
    public partial class SearchAndCheckboxControl : UserControl, INotifyPropertyChanged 
    {

        ObservableCollection<MyPair<string, bool>> search_result = new ObservableCollection<MyPair<string, bool>>();


        public SearchAndCheckboxControl()
        {
            InitializeComponent();
            SearchBar.TextChanged += SearchBar_TextChanged;            
        }

        public ObservableCollection<MyPair<string, bool>> SearchResult
        {
            get { return search_result; }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string query = SearchBar.Text.ToLower();
            SearchResult.Clear();
            foreach (var element in SearchData.Where(s => s.Key.ToLower().Contains(query)))
            {
                SearchResult.Add(element);
            }
            OnPropertyChanged(nameof(SearchResult));                
        }


        public string SearchTooltipText
        {
            get { return (string)GetValue(SearchTooltipTextProperty); }
            set { SetValue(SearchTooltipTextProperty, value); }
        }

        public List<MyPair<string, bool>> SearchData
        {
            get { return (List<MyPair<string, bool>>)GetValue(SearchDataProperty); }
            set { SetValue(SearchDataProperty, value); }
        }

        private void SelectAllButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var element in SearchData)
                element.Value = true;
        }

        private void DeselectAll_Click(object sender, RoutedEventArgs e)
        {
            foreach (var element in SearchData)
                element.Value = false;
        }



        public static readonly DependencyProperty SearchTooltipTextProperty =
            DependencyProperty.Register("SearchTooltipText", typeof(string), typeof(SearchAndCheckboxControl),
                new FrameworkPropertyMetadata(string.Empty,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender
                ));

        public static readonly DependencyProperty SearchDataProperty =
            DependencyProperty.Register("SearchData", typeof(List<MyPair<string, bool>>), 
            typeof(SearchAndCheckboxControl), new FrameworkPropertyMetadata(new List<MyPair<string,bool>>(),
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender,
                new PropertyChangedCallback(OnTextChanged), new CoerceValueCallback(CoerceText)));

       

        private static object CoerceText(DependencyObject d, object value)
        {
            return value;
        }
        


        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //...............................///
          
            
        }

        

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SearchUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            foreach(var element in SearchData)
                search_result.Add(element);
        }
    }
}
