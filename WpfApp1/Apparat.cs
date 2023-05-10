using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Apparat
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Название аппарата")]
        public string name { get; set; }

        [BsonElement("Цена (руб)")]
        public int? price { get; set; }

        [BsonElement("Гарантийный срок")]
        public int? garantee { get; set; }

        [BsonElement("Конструктивное исполнение")]
        public string construction { get; set; }

        [BsonElement("Области применения")]
        public List<string> usingFields { get; }

        [BsonElement("Пакеты специализированных программ")]
        public List<string> haveSpecialProgramms { get; }

        [BsonElement("Набор ультразвуковых датчиков")]
        public List<string> UltraSoundDevices { get; }

        [BsonElement("Руководство по эксплуатации на русском")]
        public bool haveRussInstruction { get; }

        [BsonElement("Масса (кг)")]
        public int mass { get; }

        [BsonElement("Диагональ ЖК-монитора (в дюймах)")]
        public int? diag { get; }

        [BsonElement("Страна производства")]
        public string country { get; }

        [BsonElement("Производитель")]
        public string manufacture { get; }

        [BsonElement("Минимальная ширина (см)")]
        public int? minimalWidth { get; }

        [BsonElement("Минимальная высота (см)")]
        public int? minimalHeight { get; }

        [BsonElement("Максимальная ширина (см)")]
        public int? maximalWidth { get; }

        [BsonElement("Максимальная высота (см)")]
        public int? maximalHeight { get; }


    }
}
