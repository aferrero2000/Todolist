using WpfTodolist.Entity;
using WpfTodolist.Persistance;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;

namespace WpfTodolist.Service
{
    public class ResponsableService
    {
        public static IEnumerable<Responsable> GetAll()
        {
            var result = new List<Responsable>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM Responsable";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Responsable
                            { 
                                Id = Convert.ToInt32(reader["id"].ToString()),
                                Nom = reader["nom"].ToString()
                            });
                        }
                    }
                }
            }

            return result;
        }

        public static Responsable GetOne(int identificador)
        {
            var result = new Responsable();

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM Responsable WHERE id = ?";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("id", identificador));
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Id = Convert.ToInt32(reader["id"].ToString());
                            result.Nom = reader["nom"].ToString();
                        }
                    }
                }
            }

            return result;
        }

        public static Responsable GetOne(String identificador)
        {
            var result = new Responsable();

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM Responsable WHERE nom = ?";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("nom", identificador));
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Id = Convert.ToInt32(reader["id"].ToString());
                            result.Nom = reader["nom"].ToString();
                        }
                    }
                }
            }

            return result;
        }

        public static void SetOne(Responsable responsable)
        {
            using (var ctx = DbContext.GetInstance())
            {
                var query = "INSERT INTO Responsable (nom) VALUES (?)";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("nom", responsable.Nom));

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void Update(Responsable responsable)
        {
            using (var ctx = DbContext.GetInstance())
            {
                string query = "UPDATE Responsable SET nom = ? WHERE id = ?";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("nom", responsable.Nom));
                    command.Parameters.Add(new SQLiteParameter("id", responsable.Id));

                    command.ExecuteNonQuery();
                }
            }

        }
    }
}
