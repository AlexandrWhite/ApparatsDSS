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




   

}
