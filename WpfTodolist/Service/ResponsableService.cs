using WpfTodolist.Entity;
using WpfTodolist.Persistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SQLiteExample.Service
{
    public class ResponsableService
    {
        public static IEnumerable<Responsable> GetAll()
        {
            var result = new List<Responsable>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM Tasca";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Responsable
                            { 
                                Id = Convert.ToInt32(reader["id"].ToString()),
                                Nom = reader["nom"].ToString(),
                            });
                        }
                    }
                }
            }


            return result;
        }
    }
}
