using System;
using System.Collections.Generic;
using System.Text;
using MongoDB;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Threading.Tasks;
using WpfTodolist.Api;

namespace WpfTodolist.Entity
{
    public class Tasca_Responsable
    {
        public string Id { get; set; }
        public string Nom { get; set; }
        public string Descripcio { get; set; }
        public DateTime Data_creacio { get; set; }
        public DateTime Data_finalitzacio { get; set; }
        public string Responsable { get; set; }
        public string Prioritat { get; set; }
        public string ResponsableText { get; set; }
        public string PrioritatText { get; set; }
        public string Estat { get; set; }

        public Tasca_Responsable()
        {
            Id = "";
            Nom = "";
            Descripcio = "";
            Data_creacio = new DateTime();
            Data_finalitzacio = new DateTime();
            Responsable = "";
            Prioritat = "";
            ResponsableText = "";
            PrioritatText = "";
            Estat = "";
        }

        public Tasca_Responsable(Tasca t)
        {
            ApiClient api = new ApiClient();
            List<Responsable> lr = api.GetResponsableAsync().Result;
            Responsable r = lr.Find(r => r.Id.Equals(t.Responsable));
            List<Prioritat> lp = api.GetPrioritatsAsync().Result;
            Prioritat p = lp.Find(p => p.Id.Equals(t.Prioritat));

            Id = t.Id;
            Nom = t.Nom;
            Descripcio = t.Descripcio;
            Data_creacio = t.Data_creacio;
            Data_finalitzacio = t.Data_finalitzacio;
            Responsable = t.Responsable;
            Prioritat = t.Prioritat;
            ResponsableText = r.Nom + " " + r.Cognom;
            PrioritatText = p.Color;
            Estat = t.Estat;
        }

        public Tasca_Responsable(Task<Tasca_Responsable> v)
        {
            Id = v.Result.Id;
            Nom = v.Result.Nom;
            Descripcio = v.Result.Descripcio;
            Data_creacio = v.Result.Data_creacio;
            Data_finalitzacio = v.Result.Data_finalitzacio;
            Responsable = v.Result.Responsable;
            Prioritat = v.Result.Prioritat;
            ResponsableText = v.Result.ResponsableText;
            PrioritatText = v.Result.PrioritatText;
            Estat = v.Result.Estat;
        }
    }
}
