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
     //                           Data_creacio = Convert.ToDateTime(reader["data_creacio"]),
    //                            Data_finalitzacio = Convert.ToDateTime(reader["data_finalitzacio"]),
                                Responsable = Convert.ToInt32(reader["responsable"].ToString()),
                                Prioritat = Convert.ToInt32(reader["prioritat"].ToString())
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
                            result.Descripcio = reader["descipcio"].ToString();
                            result.Data_creacio = Convert.ToDateTime(reader["data_creacio"]);
                            result.Data_finalitzacio = Convert.ToDateTime(reader["data_finalitzacio"]);
                            result.Responsable = Convert.ToInt32(reader["responsable"].ToString());
                            result.Prioritat = Convert.ToInt32(reader["prioritat"].ToString());
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
                var query = "INSERT INTO Tasca (nom, descripcio, data_creacio, data_finalitzacio, responsable, prioritat) VALUES (?, ?, ?, ?, ?, ?)";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("nom", tasca.Nom));
                    command.Parameters.Add(new SQLiteParameter("descripcio", tasca.Descripcio));
                    command.Parameters.Add(new SQLiteParameter("data_creacio", tasca.Data_creacio));
                    command.Parameters.Add(new SQLiteParameter("data_finalitzacio", tasca.Data_finalitzacio));
                    command.Parameters.Add(new SQLiteParameter("responsable", tasca.Responsable));
                    command.Parameters.Add(new SQLiteParameter("prioritat", tasca.Prioritat));

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void Update(Tasca tasca)
        {
            using (var ctx = DbContext.GetInstance())
            {
                string query = "UPDATE Tasca SET nom = ?, descripcio = ?, data_creacio = ? data_finalitzacio = ? responsable = ? prioritat = ?";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("nom", tasca.Nom));
                    command.Parameters.Add(new SQLiteParameter("descripcio", tasca.Descripcio));
                    command.Parameters.Add(new SQLiteParameter("data_creacio", tasca.Data_creacio));
                    command.Parameters.Add(new SQLiteParameter("data_finalitzacio", tasca.Data_finalitzacio));
                    command.Parameters.Add(new SQLiteParameter("responsable", tasca.Responsable));
                    command.Parameters.Add(new SQLiteParameter("prioritat", tasca.Prioritat));

                    command.ExecuteNonQuery();
                }
            }

        }

        //ID de el que es vol eliminar
        public static void Delete(int Id)
        {
            using (var ctx = DbContext.GetInstance())
            {
                string query = "DELETE FROM Users WHERE Id = ?";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("", Id));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
