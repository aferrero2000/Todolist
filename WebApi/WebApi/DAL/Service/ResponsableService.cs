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
    public class ResponsableService
    {
        readonly IMongoCollection<Responsable> responsables = DbContext.GetInstance().GetCollection<Responsable>("Responsable");

        /// <summary>
        /// Obté tots els responsables
        /// </summary>
        /// <returns>Llista de responsables</returns>
        public List<Responsable> GetAll()
        {
            return responsables.AsQueryable<Responsable>().ToList();
        }

        /// <summary>
        /// Obté un responsable
        /// </summary>
        /// <param name="Id">Codi de responsable que es vol obtenir</param>
        /// <returns>La entitat responsable trobada</returns>
        public Responsable GetOne(string Id)
        {
            return responsables.Find(r => r.Id == Id).First<Responsable>();
        }

        /// <summary>
        /// Afegeix un nou responsable a la base de dades
        /// </summary>
        /// <param name="responsable">Entitat responsable</param>
        /// <returns>El número de responsables afegits</returns>
        public int Add(Responsable responsable)
        {
            responsables.InsertOne(responsable);

            return 1;
        }

        /// <summary>
        /// Actualitza una responsable
        /// </summary>
        /// <param name="responsable">Entitat responsable que es vol modificar</param>
        /// <returns>El número de responsables modificats</returns>
        public long Update(Responsable responsable)
        {
            var filter = Builders<Responsable>.Filter.Eq(r => r.Id, responsable.Id);
            var result = responsables.ReplaceOne(filter, responsable);

            return result.MatchedCount;
        }

        /// <summary>
        /// Elimina un responsable
        /// </summary>
        /// <param name="Id">Codi de responsable que es vol eliminar</param>
        /// <returns>El número de responsables eliminats</returns>
        public long Delete(string Id)
        {
            var result = responsables.DeleteOne(r => r.Id == Id);

            return result.DeletedCount;
        }
    }
}
