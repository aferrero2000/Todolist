using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using WpfTodolist.Entity;

namespace WpfTodolist.ApiClient
{
    class PrioritatApiClient
    {
        string BaseUri;

        public PrioritatApiClient()
        {
            BaseUri = ConfigurationManager.AppSettings["BaseUri"];
        }

        /// <summary>
        /// Obté una llista de tots els usuaris de la base de dades
        /// </summary>
        /// <returns></returns>
        public async Task<List<Prioritat>> GetPrioritatsAsync()
        {
            List<Prioritat> prioritats = new List<Prioritat>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició GET al endpoint /tascas}
                HttpResponseMessage response = await client.GetAsync("prioritat");
                if (response.IsSuccessStatusCode)
                {
                    //Obtenim el resultat i el carreguem al objecte llista d'usuaris
                    prioritats = await response.Content.ReadAsAsync<List<Prioritat>>();
                    response.Dispose();
                }
                else
                {
                    //TODO: que fer si ha anat malament? retornar null? missatge?
                }
            }
            return prioritats;
        }

        /// <summary>
        /// Afegeix un nou usuari
        /// </summary>
        /// <param name="user">Usuari que volem afegir</param>
        /// <returns></returns>
        public async Task AddAsync(Prioritat prioritat)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició POST al endpoint /users}
                HttpResponseMessage response = await client.PostAsJsonAsync("id", prioritat);
                response.EnsureSuccessStatusCode();
            }
        }

        /// <summary>
        /// Modificar un usuari
        /// </summary>
        /// <param name="user">Usuari que volem modificar</param>
        /// <returns></returns>
        public async Task UpdateAsync(Prioritat prioritat)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició PUT al endpoint /users/Id
                HttpResponseMessage response = await client.PutAsJsonAsync($"tasca/{prioritat.Id}", prioritat);
                response.EnsureSuccessStatusCode();
            }
        }

        public async Task DeleteAsync(string Id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició DELETE al endpoint /users/Id
                HttpResponseMessage response = await client.DeleteAsync($"prioritat/{Id}");
                response.EnsureSuccessStatusCode();
            }
        }

        /// <summary>
        /// Obté un usuari a partir del Id
        /// </summary>
        /// <param name="Id">Codi d'usuari</param>
        /// <returns>Usuari o null si no el troba</returns>
        public async Task<Prioritat> GetUserAsync(int Id)
        {
            Prioritat prioritats = new Prioritat();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició GET al endpoint /users/{Id}
                HttpResponseMessage response = await client.GetAsync($"prioritat/id/{Id}");
                if (response.IsSuccessStatusCode)
                {
                    //Reposta 204 quan no ha trobat dades
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        prioritats = null;
                    }
                    else
                    {
                        //Obtenim el resultat i el carreguem al Objecte User
                        prioritats = await response.Content.ReadAsAsync<Prioritat>();
                        response.Dispose();
                    }
                }
                else
                {
                    //TODO: que fer si ha anat malament? retornar null? 
                }
            }
            return prioritats;
        }
    }
}
