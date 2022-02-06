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
    public class Tasca
    {
        public string Id { get; set; }
        public string Nom { get; set; }
        public string Descripcio { get; set; }
        public DateTime Data_creacio { get; set; }
        public DateTime Data_finalitzacio { get; set; }
        public string Responsable { get; set; }
        public string Prioritat { get; set; }
        public string Estat { get; set; }

        public Tasca()
        {
            Id = "";
            Nom = "";
            Descripcio = "";
            Data_creacio = new DateTime();
            Data_finalitzacio = new DateTime();
            Responsable = "";
            Prioritat = "";
            Estat = "";
        }

        public Tasca(Tasca_Responsable tr)
        {
            Id = tr.Id;
            Nom = tr.Nom;
            Descripcio = tr.Descripcio;
            Data_creacio = tr.Data_creacio;
            Data_finalitzacio = tr.Data_finalitzacio;
            Responsable = tr.Responsable;
            Prioritat = tr.Prioritat;
            Estat = tr.Estat;
        }

        public Tasca(Task<Tasca> tt)
        {
            Id = tt.Result.Id;
            Nom = tt.Result.Nom;
            Descripcio = tt.Result.Descripcio;
            Data_creacio = tt.Result.Data_creacio;
            Data_finalitzacio = tt.Result.Data_finalitzacio;
            Responsable = tt.Result.Responsable;
            Prioritat = tt.Result.Prioritat;
            Estat = tt.Result.Estat;
        }
    }
}
