using System;
using System.Collections.Generic;
using System.Text;
using MongoDB;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WpfTodolist.Entity
{
    public class Prioritat
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("Color")]
        public string Color { get; set; }
        [BsonElement("Nom")]
        public string Nom { get; set; }
    }
}
