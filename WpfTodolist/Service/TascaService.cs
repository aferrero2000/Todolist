using WpfTodolist.Entity;
using WpfTodolist.Persistance;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;

namespace WpfTodolist.Service
{
    public class TascaService
    {
        public static IEnumerable<Tasca> GetAll()
        {
            var result = new List<Tasca>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM Tasca";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Tasca
                            { 
                                Id = Convert.ToInt32(reader["id"].ToString()),
                                Nom = reader["nom"].ToString(),
                                Descripcio = reader["descipcio"].ToString(),
                                Data_creacio = Convert.ToDateTime(reader["data_creacio"]),
                                Data_finalitzacio = Convert.ToDateTime(reader["data_finalitzacio"]),
                                Responsable = Convert.ToInt32(reader["responsable"].ToString()),
                                Prioritat = Convert.ToInt32(reader["prioritat"].ToString()),
                            });
                        }
                    }
                }
            }


            return result;
        }
    }
}
