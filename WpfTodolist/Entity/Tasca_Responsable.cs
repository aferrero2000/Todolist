using System;
using System.Collections.Generic;
using System.Text;
using MongoDB;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WpfTodolist.Entity
{
    public class Tasca_Responsable
    {
        public ObjectId Id { get; set; }
        public string Nom { get; set; }
        public string Descripcio { get; set; }
        public DateTime Data_creacio { get; set; }
        public DateTime Data_finalitzacio { get; set; }
        public ObjectId Responsable { get; set; }
        public ObjectId Prioritat { get; set; }
        public string ResponsableText { get; set; }
        public string PrioritatText { get; set; }
        public string Estat { get; set; }
    }
}
