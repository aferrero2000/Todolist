using System;
using System.Collections.Generic;
using System.Text;
using MongoDB;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebApi.Model
{
    public class Tasca
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Nom")]
        public string Nom { get; set; }
        [BsonElement("Descripcio")]
        public string Descripcio { get; set; }
        [BsonElement("Data_creacio")]
        public DateTime Data_creacio { get; set; }
        [BsonElement("Data_finalitzacio")]
        public DateTime Data_finalitzacio { get; set; }
        [BsonElement("Responsable")]
        public string Responsable { get; set; }
        [BsonElement("Prioritat")]
        public string Prioritat { get; set; }
        [BsonElement("Estat")]
        public string Estat { get; set; }
    }
}
