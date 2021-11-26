using System;
using System.Data.SQLite;
using System.IO;

namespace WpfTodolist.Persistance
{
    public class DbContext
    {
        private const string DBName = @"database.sqlite";
        private const string SQLScript = @"..\..\..\Util\database.sql";
        private static bool IsDbRecentlyCreated = false;

        public static void Up()
        {
            // Crea la base de datos solo una vez
            if (!File.Exists(Path.GetFullPath(DBName)))
            {
                SQLiteConnection.CreateFile(DBName);
                IsDbRecentlyCreated = true;
            }

            using (var ctx = GetInstance())
            {
                // Crea la base de datos solo la primera vez
                if (IsDbRecentlyCreated)
                {
                    using (var reader = new StreamReader(Path.GetFullPath(SQLScript)))
                    {
                        var query = "";
                        var line = "";
                        while ((line = reader.ReadLine()) != null)
                        {
                            query += line;
                        }

                        using (var command = new SQLiteCommand(query, ctx))
                        {
                            command.ExecuteNonQuery();
                        }
                    }

                    /** TEST DATA

                    for (var i = 1; i <= 10; i++)//Responsable
                    {
                        var query = "INSERT INTO Responsable (nom) VALUES (?)";

                        using (var command = new SQLiteCommand(query, ctx))
                        {
                            command.Parameters.Add(new SQLiteParameter("nom", "Nom " + i));

                            command.ExecuteNonQuery();
                        }
                    }

                    for (var i = 1; i <= 10; i++)//Tasca
                    {
                        var query = "INSERT INTO Tasca (nom, descripcio, data_creacio, data_finalitzacio, responsable, prioritat, estat) VALUES (?, ?, ?, ?, ?, ?, ?)";

                        using (var command = new SQLiteCommand(query, ctx))
                        {
                            command.Parameters.Add(new SQLiteParameter("nom", "Nom " + i));
                            command.Parameters.Add(new SQLiteParameter("descripcio", "Descripcio " + i));
                            command.Parameters.Add(new SQLiteParameter("data_creacio", DateTime.Today));
                            var rand = new Random();
                            command.Parameters.Add(new SQLiteParameter("data_finalitzacio", DateTime.Today.AddDays(rand.Next(2,7))));
                            command.Parameters.Add(new SQLiteParameter("responsable", i));
                            command.Parameters.Add(new SQLiteParameter("prioritat", "Red"));
                            command.Parameters.Add(new SQLiteParameter("estat", "ToDo"));

                            command.ExecuteNonQuery();
                        }
                    }
                    **/
                }
            }
        }

        public static SQLiteConnection GetInstance()
        {
            var db = new SQLiteConnection(
                string.Format("Data Source={0};Version=3;", DBName)
            );

            db.Open();

            return db;
        }
    }
}
