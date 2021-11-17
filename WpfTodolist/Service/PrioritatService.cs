using WpfTodolist.Entity;
using WpfTodolist.Persistance;
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
                                Color = reader["Color"].ToString()
                            });
                        }
                    }
                }
            }


            return result;
        }

        public static Prioritat GetOne(int identificador)
        {
            var result = new Prioritat();

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM Prioritat WHERE id = " + identificador;

                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Id = Convert.ToInt32(reader["id"].ToString());
                            result.Nom = reader["nom"].ToString();
                            result.Color = reader["color"].ToString();
                        }
                    }
                }
            }

            return result;
        }

        public static void SetOne(Prioritat prioritat)
        {
            using (var ctx = DbContext.GetInstance())
            {
                var query = "INSERT INTO Prioritat (nom, color) VALUES (?, ?)";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("nom", prioritat.Nom));
                    command.Parameters.Add(new SQLiteParameter("color", prioritat.Color));

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
