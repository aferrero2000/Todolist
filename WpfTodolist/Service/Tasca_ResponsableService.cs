using WpfTodolist.Entity;
using WpfTodolist.Persistance;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;

namespace WpfTodolist.Service
{
    class Tasca_ResponsableService
    {

        public static Tasca_Responsable GetNomResponsable(Tasca tasca)
        {
            var responsable = new Responsable();

            using (var ctx = DbContext.GetInstance())
            {
                
                var query = "SELECT * FROM Responsable WHERE id = ?";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("id", tasca.Responsable));
                    using (var reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            Debug.WriteLine(reader);
                            responsable.Nom = reader["Nom"].ToString();
                        }
                    }
                }
            }

            var result = new Tasca_Responsable();
            result.Id = tasca.Id;
            result.Nom = tasca.Nom;
            result.Descripcio = tasca.Descripcio;
            result.Data_creacio = tasca.Data_creacio;
            result.Data_finalitzacio = tasca.Data_finalitzacio;
            result.Prioritat = tasca.Prioritat;
            result.Responsable = responsable.Nom;
            result.Estat = tasca.Estat;

            return result;
        }

    }
}
