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
                                Descripcio = reader["descripcio"].ToString(),
                                Data_creacio = Convert.ToDateTime(reader["data_creacio"]),
                                Data_finalitzacio = Convert.ToDateTime(reader["data_finalitzacio"]),
                                Responsable = Convert.ToInt32(reader["responsable"].ToString()),
                                Prioritat = reader["prioritat"].ToString(),
                                Estat = reader["estat"].ToString()
                            });
                        }
                    }
                }
            }

            return result;
        }

        public static IEnumerable<Tasca> GetAll(String estat)
        {
            var result = new List<Tasca>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM Tasca WHERE Estat = ?";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("estat", estat));

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Tasca
                            {
                                Id = Convert.ToInt32(reader["id"].ToString()),
                                Nom = reader["nom"].ToString(),
                                Descripcio = reader["descripcio"].ToString(),
                                Data_creacio = Convert.ToDateTime(reader["data_creacio"]),
                                Data_finalitzacio = Convert.ToDateTime(reader["data_finalitzacio"]),
                                Responsable = Convert.ToInt32(reader["responsable"].ToString()),
                                Prioritat = reader["prioritat"].ToString(),
                                Estat = reader["estat"].ToString()
                            });
                        }
                    }
                }
            }

            return result;
        }

        public static Tasca GetOne(int identificador)
        {
            var result = new Tasca();

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM Tasca WHERE id = " + identificador;

                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Id = Convert.ToInt32(reader["id"].ToString());
                            result.Nom = reader["nom"].ToString();
                            result.Descripcio = reader["descripcio"].ToString();
                            result.Data_creacio = Convert.ToDateTime(reader["data_creacio"]);
                            result.Data_finalitzacio = Convert.ToDateTime(reader["data_finalitzacio"]);
                            result.Responsable = Convert.ToInt32(reader["responsable"].ToString());
                            result.Prioritat = reader["prioritat"].ToString();
                            result.Estat = reader["estat"].ToString();
                        }
                    }
                }
            }

            return result;
        }

        public static void SetOne(Tasca tasca)
        {
            using (var ctx = DbContext.GetInstance())
            {
                var query = "INSERT INTO Tasca (nom, descripcio, data_creacio, data_finalitzacio, responsable, prioritat, estat) VALUES (?, ?, ?, ?, ?, ?, ?)";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("nom", tasca.Nom));
                    command.Parameters.Add(new SQLiteParameter("descripcio", tasca.Descripcio));
                    command.Parameters.Add(new SQLiteParameter("data_creacio", tasca.Data_creacio));
                    command.Parameters.Add(new SQLiteParameter("data_finalitzacio", tasca.Data_finalitzacio));
                    command.Parameters.Add(new SQLiteParameter("responsable", tasca.Responsable));
                    command.Parameters.Add(new SQLiteParameter("prioritat", tasca.Prioritat));
                    command.Parameters.Add(new SQLiteParameter("estat", tasca.Estat));

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateEstat(String estat, int id)
        {
            using (var ctx = DbContext.GetInstance())
            {
                string query = "UPDATE Tasca SET estat = ? WHERE id = ?";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("estat", estat));
                    command.Parameters.Add(new SQLiteParameter("id", id));

                    command.ExecuteNonQuery();
                }
            }

        }

        public static void UpdateNoEstat(Tasca tasca)
        {
            using (var ctx = DbContext.GetInstance())
            {
                string query = "UPDATE Tasca SET nom = ?, descripcio = ?, data_creacio = ?, data_finalitzacio = ?, responsable = ?, prioritat = ? WHERE id = ?";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("nom", tasca.Nom));
                    command.Parameters.Add(new SQLiteParameter("descripcio", tasca.Descripcio));
                    command.Parameters.Add(new SQLiteParameter("data_creacio", tasca.Data_creacio));
                    command.Parameters.Add(new SQLiteParameter("data_finalitzacio", tasca.Data_finalitzacio));
                    command.Parameters.Add(new SQLiteParameter("responsable", tasca.Responsable));
                    command.Parameters.Add(new SQLiteParameter("prioritat", tasca.Prioritat));
                    command.Parameters.Add(new SQLiteParameter("id", tasca.Id));


                    command.ExecuteNonQuery();
                }
            }

        }

        //ID de el que es vol eliminar
        public static void Delete(int Id)
        {
            using (var ctx = DbContext.GetInstance())
            {
                string query = "DELETE FROM Tasca WHERE Id = ?";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("", Id));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
