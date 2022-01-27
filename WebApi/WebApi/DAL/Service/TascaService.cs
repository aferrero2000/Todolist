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
    public class TascaService
    {
        readonly IMongoCollection<Tasca> tasques = DbContext.GetInstance().GetCollection<Tasca>("Tasca");

        /// <summary>
        /// Obté totes les tasques
        /// </summary>
        /// <returns>Llista de tasques</returns>
        public List<Tasca> GetAll()
        {
            return tasques.AsQueryable<Tasca>().ToList();
        }

        /// <summary>
        /// Obté totes les tasques amb un estat concret
        /// </summary>
        /// <param name="estat">Atribut estat que es vol buscar</param>
        /// <returns>Llista de tasques</returns>
        public List<Tasca> GetAll(string estat)
        {
            return tasques.Find(t => t.Estat == estat).ToList();
        }

        /// <summary>
        /// Obté totes les tasques amb un responsable concret
        /// </summary>
        /// <param name="responsable">Atribut responsable que es vol buscar</param>
        /// <returns>Llista de tasques</returns>
        /*public List<Tasca> GetAll(string responsable)
        {
            return tasques.Find(t => t.Responsable == responsable).ToList();
        }*/

        /// <summary>
        /// Obté una tasca
        /// </summary>
        /// <param name="Id">Codi de tasca que es vol obtenir</param>
        /// <returns>La entitat tasca trobada</returns>
        public Tasca GetOne(string Id)
        {
            return tasques.Find(t => t.Id == Id).First<Tasca>();
        }

        /// <summary>
        /// Afegeix una nova tasca a la base de dades
        /// </summary>
        /// <param name="tasca">Entitat tasca</param>
        /// <returns>El número de tasques afegits</returns>
        public int Add(Tasca tasca)
        {
            tasques.InsertOne(tasca);

            return 1;
        }

        /// <summary>
        /// Actualitza una tasca
        /// </summary>
        /// <param name="tasca">Entitat tasca que es vol modificar</param>
        /// <returns>El número de tasques modificades</returns>
        public long Update(Tasca tasca)
        {
            var filter = Builders<Tasca>.Filter.Eq(r => r.Id, tasca.Id);
            var result = tasques.ReplaceOne(filter, tasca);

            return result.MatchedCount;
        }

        /// <summary>
        /// Elimina una tasca
        /// </summary>
        /// <param name="Id">Codi de tasca que es vol eliminar</param>
        /// <returns>El número de tasques eliminades</returns>
        public long Delete(string Id)
        {
            var result = tasques.DeleteOne(t => t.Id == Id);

            return result.DeletedCount;
        }

    }
}