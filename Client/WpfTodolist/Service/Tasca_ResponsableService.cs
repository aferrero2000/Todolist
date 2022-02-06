using WpfTodolist.Entity;
using WpfTodolist.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace WpfTodolist.Service
{
    class Tasca_ResponsableService
    {
        ApiClient api = new ApiClient();
        public Tasca_Responsable GetNomResponsable(Tasca tasca)
        {
            List<Responsable> lr = api.GetResponsableAsync().Result;
            Responsable responsable = lr.Find(r => r.Id.Equals(tasca.Responsable));
            List<Prioritat> lp = api.GetPrioritatsAsync().Result;
            Prioritat prioritat = lp.Find(p => p.Id.Equals(tasca.Prioritat));

            var result = new Tasca_Responsable();
            result.Id = tasca.Id;
            result.Nom = tasca.Nom;
            result.Descripcio = tasca.Descripcio;
            result.Data_creacio = tasca.Data_creacio;
            result.Data_finalitzacio = tasca.Data_finalitzacio;
            result.Responsable = tasca.Responsable;
            result.Prioritat = tasca.Prioritat;
            result.ResponsableText = responsable.Nom + ' ' + responsable.Cognom;
            result.PrioritatText = prioritat.Color.ToString();
            result.Estat = tasca.Estat;

            return result;
        }

        public Tasca Refactor(Tasca_Responsable tasca_Responsable)
        {
            Tasca tasca = new Tasca();
            tasca.Id = tasca_Responsable.Id;
            tasca.Nom = tasca_Responsable.Nom;
            tasca.Descripcio = tasca_Responsable.Descripcio;
            tasca.Data_creacio = tasca_Responsable.Data_creacio;
            tasca.Data_finalitzacio = tasca_Responsable.Data_finalitzacio;
            tasca.Responsable = tasca_Responsable.Responsable;
            tasca.Prioritat = tasca_Responsable.Prioritat;
            tasca.Estat = tasca_Responsable.Estat;
            return tasca;
        }

    }
}
