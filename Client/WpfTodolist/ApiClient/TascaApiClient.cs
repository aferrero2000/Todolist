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
    class TascaApiClient
    {
        string BaseUri;

        public TascaApiClient()
        {
            BaseUri = ConfigurationManager.AppSettings["BaseUri"];
        }

        /// <summary>
        /// Obté una llista de tots els usuaris de la base de dades
        /// </summary>
        /// <returns></returns>
        public async Task<List<Tasca>> GetTasquesAsync()
        {
            List<Tasca> tascas = new List<Tasca>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició GET al endpoint /tascas}
                HttpResponseMessage response = await client.GetAsync("tasca");
                if (response.IsSuccessStatusCode)
                {
                    //Obtenim el resultat i el carreguem al objecte llista d'usuaris
                    tascas = await response.Content.ReadAsAsync<List<Tasca>>();
                    response.Dispose();
                }
                else
                {
                    //TODO: que fer si ha anat malament? retornar null? missatge?
                }
            }
            return tascas;
        }
    }
}
