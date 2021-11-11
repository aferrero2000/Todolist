using WpfTodolist.Entity;
using WpfTodolist.Persistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;

namespace WpfTodolist.Service
{
    public class PrioritatService
    {
        public static IEnumerable<Prioritat> GetAll()
        {
            var result = new List<Prioritat>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM Prioritat";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Prioritat
                            {
                                Id = Convert.ToInt32(reader["ID"].ToString()),
                                Nom = reader["Nom"].ToString(),
                                Color = reader["Color"].ToString(),
                            });
                        }
                    }
                }
            }


            return result;
        }
    }
}
