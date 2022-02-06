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
    public class Responsable
    {
        public string Id { get; set; }
        public string Nom { get; set; }
        public string Cognom { get; set; }

        public Responsable()
        {
            Id = "";
            Nom = "";
            Cognom = "";
        }

        public Responsable(Task<Responsable> tr)
        {
            Id = tr.Result.Id;
            Nom = tr.Result.Nom;
            Cognom = tr.Result.Cognom;
        }
    }
}
