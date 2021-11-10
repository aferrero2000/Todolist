using WpfTodolist.Entity;
using WpfTodolist.Persistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SQLiteExample.Service
{
    public class PrioritatService
    {
        public static IEnumerable<Prioritat> GetAll()
        {
            var result = new List<Prioritat>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM Tasca";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Prioritat
                            {
                                Id = Convert.ToInt32(reader["id"].ToString()),
                                Nom = reader["nom"].ToString(),
                                Color = reader["color"].ToString(),
                            });
                        }
                    }
                }
            }


            return result;
        }
    }
}
