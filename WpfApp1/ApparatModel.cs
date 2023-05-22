using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;


namespace WpfApp1
{
    class ApparatDB
    {
        static MongoClient client = new MongoClient("mongodb://localhost:27017");
        public static MongoClient MongoClient
        {
            get
            {
                return client;
            }
        }
    }



    //class ApparatFilterModel : INotifyPropertyChanged
    //{

        

    //    Dictionary<string, FilterDefinition<Apparat>> filters = new Dictionary<string, FilterDefinition<Apparat>>(); 


    //    public ApparatFilterModel(){

    //        foreach (var element in Countries)
    //            element.PropertyChanged += CountriesPropertyChanged;
    //    }

    //    private void CountriesPropertyChanged(object sender, PropertyChangedEventArgs e)
    //    {
    //        var selected_countries = Countries.FindAll(item => item.Value == true).Select(item => item.Key).ToList();
    //        var filter = Builders<Apparat>.Filter.In("Страна производства", selected_countries);

    //        if (selected_countries.Count == 0)
    //            filters["Страна производства"] = Builders<Apparat>.Filter.Empty;
    //        else
    //            filters["Страна производства"] = filter;

    //        OnPropertyChanged(nameof(Apparats));
    //    }

      

    //    //public List<MyPair<string, bool>> Countries
    //    //{
    //    //    get { return countries_data; }
    //    //}

    //    bool have_russian_doc = false;
    //    public bool HaveRussianInstuction
    //    {
    //        get { return have_russian_doc; }
    //        set { have_russian_doc = value; }
    //    }
       

    //    public List<Apparat> Apparats
    //    {           
    //        get
    //        {
    //            Console.WriteLine("Apparat");

    //            var mainFilter = Builders<Apparat>.Filter.Empty;
    //            foreach (var element in filters)                
    //                mainFilter &= element.Value;
                

    //            var collection = ApparatDB.MongoClient.GetDatabase("test").GetCollection<Apparat>("apparats").Find(mainFilter).ToList();
    //            return collection;
    //        }
            
    //    }
    



        

    //    public event PropertyChangedEventHandler PropertyChanged;
    //    protected virtual void OnPropertyChanged(string propertyName)
    //    {
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //    }
    //}


   

}
