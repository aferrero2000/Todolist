using System;
using System.Data.SQLite;
using System.IO;
using MongoDB;  
using MongoDB.Bson;
using MongoDB.Driver;

namespace WpfTodolist.Persistance
{
    public class DbContext
    {
        public static IMongoDatabase GetInstance()
        {
            string connectionString = "mongodb+srv://admin:1234@cluster0.trls0.mongodb.net/ToDoList?retryWrites=true&w=majority";
            MongoClient mongoClient = new MongoClient(connectionString);
            return mongoClient.GetDatabase("ToDoList");
        }
    }
}