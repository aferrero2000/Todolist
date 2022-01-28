using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Service;
using WebApi.Model;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;


namespace WebApi.Controllers
{
    [Route("api/tasca")]
    [ApiController]
    public class TascaController : ControllerBase
    {
        // GET: tasca
        [HttpGet]
        public List<Tasca> Get()
        {
            TascaService objTascaService = new TascaService();
            return objTascaService.GetAll();
        }

        //GET: tasca id??
        [HttpGet("id/{id}")]
        public Tasca Get(string id)
        {
            TascaService objUserService = new TascaService();
            return objUserService.GetOne(id);
        }

        // POST tasca
        [HttpPost]
        public void Post([FromBody] Tasca tasca)
        {
            TascaService objUserService = new TascaService();
            objUserService.Add(tasca);
        }

        // GET: Respnsable x Tasca
        [HttpGet("responsable/{id}")]
        public List<Tasca> Gett(string responsable)
        {
            TascaService objUserService = new TascaService();
            return objUserService.GetAll(responsable);
        }

        // PUT tasca/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Tasca tasca)
        {
            TascaService objtascaService = new TascaService();
            objtascaService.Update(tasca, id);
        }

        // DELETE responsable/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            TascaService objTascaService = new TascaService();
            objTascaService.Delete(id);
        }

        
    }
}
