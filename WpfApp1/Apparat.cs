using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    [BsonIgnoreExtraElements]
    class Apparat
    {    
          
        [BsonElement("Название аппарата")]
        public string Name { get; set; }

        [BsonElement("Цена (руб)")]
        public int? Price { get; set; }

        [BsonElement("Страна производства")]
        public string Country { get; set; }

        [BsonElement("Конструктивное исполнение")]
        public string Construction { get; set; }

        
        [BsonElement("Набор ультразвуковых датчиков")]
        private List<string> ultraSound { get; set; }

        public string UltraSound 
        {
            get
            {
                if (ultraSound == null){
                    Console.WriteLine(Name);
                    return "";

                }
                return String.Join(',', ultraSound);
            }           
        }


        [BsonElement("Области применения")]
        private List<string> usingFields { get; set; }
        public string UsingFields
        {
            get
            {
                return String.Join(',', usingFields);
            }
        }

    }
}
