using System;
using System.Collections.Generic;
using System.Text;
using MongoDB;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebApi.Model
{
    public class Responsable
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        [BsonElement("Nom")]
        public string Nom { get; set; }
        [BsonElement("Cognom")]
        public string Cognom { get; set; }
    }
}
