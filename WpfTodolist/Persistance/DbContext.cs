﻿using System;
using System.Data.SQLite;
using System.IO;

namespace WpfTodolist.Persistence
{
    public class DbContext
    {
        private const string DBName = "database.sqlite";
        private const string SQLScript = @"..\..\Util\database.sql";
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

                    for (var i = 1; i <= 100; i++)//Prioritat
                    {
                        var query = "INSERT INTO Prioritat (nom, color) VALUES (?, ?)";

                        using (var command = new SQLiteCommand(query, ctx))
                        {
                            command.Parameters.Add(new SQLiteParameter("nom", "Nom " + i));
                            command.Parameters.Add(new SQLiteParameter("color", "Color " + i));
//                            var rnd = new Random();
//                            command.Parameters.Add(new SQLiteParameter("birthday", DateTime.Today.AddYears(-rnd.Next(1, 50))));
                            command.ExecuteNonQuery();
                        }
                    }

                    for (var i = 1; i <= 100; i++)//Responsable
                    {
                        var query = "INSERT INTO Responsable (nom) VALUES (?)";

                        using (var command = new SQLiteCommand(query, ctx))
                        {
                            command.Parameters.Add(new SQLiteParameter("nom", "Nom " + i));

                            command.ExecuteNonQuery();
                        }
                    }

                    for (var i = 1; i <= 100; i++)//Tasca
                    {
                        var query = "INSERT INTO Tasca (nom, descripcio, data_creacio, data_finialitzacio, responsable, prioritat) VALUES (?, ?, ?, ?, ?, ?)";

                        using (var command = new SQLiteCommand(query, ctx))
                        {
                            command.Parameters.Add(new SQLiteParameter("nom", "Nom " + i));
                            command.Parameters.Add(new SQLiteParameter("descripcio", "Descripcio " + i));
                            command.Parameters.Add(new SQLiteParameter("data_creacio", "Data creació " + i));
                            command.Parameters.Add(new SQLiteParameter("data_finialitzacio", "Data finalització " + i));
                            command.Parameters.Add(new SQLiteParameter("responsable", "Responsable " + i));
                            command.Parameters.Add(new SQLiteParameter("prioritat", "Prioritat " + i));

                            command.ExecuteNonQuery();
                        }
                    }

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
