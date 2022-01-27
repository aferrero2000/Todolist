using WebApi.Model;
using WebApi.Persistance;
using System;
using System.Collections;
using System.Collections.Generic;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WebApi.Service
{

    public class PrioritatService
    {
        readonly IMongoCollection<Prioritat> prioritats = DbContext.GetInstance().GetCollection<Prioritat>("Prioritat");

        /// <summary>
        /// Obté totes les prioritats
        /// </summary>
        /// <returns>Llista de prioritats</returns>
        public List<Prioritat> GetAll()
        {
            return prioritats.AsQueryable<Prioritat>().ToList();
        }

        /// <summary>
        /// Obté una prioritat
        /// </summary>
        /// <param name="Id">Codi de prioritat que es vol obtenir</param>
        /// <returns>La entitat prioritat trobada</returns>
        public Prioritat GetOne(string Id)
        {
            return prioritats.Find(p => p.Id == Id).First<Prioritat>();
        }

        /// <summary>
        /// Obté una prioritat
        /// </summary>
        /// <param name="Id">Nom de prioritat que es vol obtenir</param>
        /// <returns>La entitat prioritat trobada</returns>

        /// <summary>
        /// Afegeix una nova prioritat a la base de dades
        /// </summary>
        /// <param name="tasca">Entitat prioritat</param>
        /// <returns>El número de prioritats afegits</returns>
        public int Add(Prioritat prioritat)
        {
            prioritats.InsertOne(prioritat);

            return 1;
        }

        /// <summary>
        /// Actualitza una prioritat
        /// </summary>
        /// <param name="prioritat">Entitat prioritat que es vol modificar</param>
        /// <returns>El número de prioritats modificades</returns>
        public long Update(Prioritat prioritat)
        {
            var filter = Builders<Prioritat>.Filter.Eq(p => p.Id, prioritat.Id);
            var result = prioritats.ReplaceOne(filter, prioritat);

            return result.MatchedCount;
        }

        /// <summary>
        /// Elimina una prioritat
        /// </summary>
        /// <param name="Id">Codi de prioritat que es vol eliminar</param>
        /// <returns>El número de prioritats eliminades</returns>
        public long Delete(string Id)
        {
            var result = prioritats.DeleteOne(p => p.Id == Id);

            return result.DeletedCount;
        }
    }
}
