using WpfTodolist.Entity;
using WpfTodolist.Persistance;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WpfTodolist.Service
{
    class Tasca_ResponsableService
    {
        PrioritatService ps = new PrioritatService();
        ResponsableService rs = new ResponsableService();
        public Tasca_Responsable GetNomResponsable(Tasca tasca)
        {
            Responsable responsable = rs.GetOne(tasca.Responsable);
            Prioritat prioritat = ps.GetOne(tasca.Prioritat);

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

    }
}
