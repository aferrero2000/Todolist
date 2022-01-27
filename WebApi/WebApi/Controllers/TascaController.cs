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

        //GET: tasca estat??
        [HttpGet("estat/{estat}")]
        public List<Tasca> Get(string estat)
        {
            TascaService objUserService = new TascaService();
            return objUserService.GetAll(estat);
        }

        //GET: tasca id??
        [HttpGet("id/{id}")]
        /*public Tasca Get(string id)
        {
            TascaService objUserService = new TascaService();
            return objUserService.GetOne(id);
        }*/

        // POST tasca
        [HttpPost]
        public void Post([FromBody] Tasca tasca)
        {
            TascaService objUserService = new TascaService();
            objUserService.Add(tasca);
        }

        // GET: Respnsable x Tasca
        [HttpGet("responsable/{string}")]
        public List<Tasca> Gett(string responsable)
        {
            TascaService objUserService = new TascaService();
            return objUserService.GetAll(responsable);
        }

        // PUT tasca/5
        [HttpPut("{id}")]
        public void Put([FromRouteAttribute] string id, [FromBody] Tasca tasca)
        {
            TascaService objtascaService = new TascaService();
            objtascaService.Update(tasca);
        }

        // DELETE responsable/5
        [HttpDelete("{string}")]
        public void Delete(string id)
        {
            TascaService objTascaService = new TascaService();
            objTascaService.Delete(id);
        }

        // GET tasca/responsable/5
        /*
        [HttpGet("responsable/{string}")]
        public Tasca Get(string responsable)
        {
            
            //UserService objUserService = new UserService();
            //return objUserService.GetById(id);
            
        }
        
        // GET tasca/Alta (prioritat
        [HttpGet("{estat}")]
        public Tasca Get(string estat)
        {
            
            //UserService objUserService = new UserService();
            //return objUserService.GetById(id);
            
        }
        

        
     


        [HttpPut("{string}")]
        public void
        // PUT tasca/5
        [HttpPut("{string}")]
        public void Put(string id, [FromBody] Tasca tasca)
        {
            
            //UserService objUserService = new UserService();
            //objUserService.Update(user);
            
        }

        // DELETE tasca/5
        [HttpDelete("{string}")]
        public void Delete(string id)
        {
            
            //UserService objUserService = new UserService();
            //objUserService.Delete(id);
            
        }*/
    }
}
