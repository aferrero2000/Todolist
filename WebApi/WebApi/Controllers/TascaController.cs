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
        public Tasca Get(ObjectId id)
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
        [HttpGet("responsable/{ObjectId}")]
        public List<Tasca> Gett(ObjectId responsable)
        {
            TascaService objUserService = new TascaService();
            return objUserService.GetAll(responsable);
        }

        // PUT tasca/5
        [HttpPut("{id}")]
        public void Put([FromRouteAttribute] ObjectId id, [FromBody] Tasca tasca)
        {
            TascaService objtascaService = new TascaService();
            objtascaService.Update(tasca);
        }


        // GET tasca/responsable/5
        /*
        [HttpGet("responsable/{ObjectId}")]
        public Tasca Get(ObjectId responsable)
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
        

        
     


        [HttpPut("{ObjectId}")]
        public void
        // PUT tasca/5
        [HttpPut("{ObjectId}")]
        public void Put(ObjectId id, [FromBody] Tasca tasca)
        {
            
            //UserService objUserService = new UserService();
            //objUserService.Update(user);
            
        }

        // DELETE tasca/5
        [HttpDelete("{ObjectId}")]
        public void Delete(ObjectId id)
        {
            
            //UserService objUserService = new UserService();
            //objUserService.Delete(id);
            
        }*/
    }
}
