using System;
using System.Collections.Generic;
using System.Text;
using MongoDB;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WpfTodolist.Entity
{
    public class Tasca
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("Nom")]
        public string Nom { get; set; }
        [BsonElement("Descripcio")]
        public string Descripcio { get; set; }
        [BsonElement("Data_creacio")]
        public DateTime Data_creacio { get; set; }
        [BsonElement("Data_finalitzacio")]
        public DateTime Data_finalitzacio { get; set; }
        [BsonElement("Responsable")]
        public ObjectId Responsable { get; set; }
        [BsonElement("Prioritat")]
        public ObjectId Prioritat { get; set; }
        [BsonElement("Estat")]
        public string Estat { get; set; }
    }
}
