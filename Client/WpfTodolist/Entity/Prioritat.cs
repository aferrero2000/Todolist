using System;
using System.Collections.Generic;
using System.Text;
using MongoDB;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace WpfTodolist.Entity
{
    public class Prioritat
    {
        public string Id { get; set; }
        public string Color { get; set; }
        public string Nom { get; set; }
    }
}
