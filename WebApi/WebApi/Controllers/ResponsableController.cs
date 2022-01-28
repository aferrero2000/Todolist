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
    [Route("api/responsable")]
    [ApiController]
    public class ResponsableController : ControllerBase
    {
        // GET: responsable
        [HttpGet]
        public List<Responsable> Get()
        {
            ResponsableService objResponsableSerice = new ResponsableService();
            return objResponsableSerice.GetAll();
        }

        // GET responsable/5
        [HttpGet("{string}")]
        public Responsable Get(string id)
        {
            ResponsableService objResponsableSerice = new ResponsableService();
            return objResponsableSerice.GetOne(id);
        }

        // POST responsable
        [HttpPost]
        public void Post([FromBody] Responsable responsable)
        {
            ResponsableService objResponsableSerice = new ResponsableService();
            objResponsableSerice.Add(responsable);
        }

        // PUT responsable/5
        [HttpPut("id/{id}")]
        public void Put(string id, [FromBody] Responsable responsable)
        {
            ResponsableService objResponsableSerice = new ResponsableService();
            objResponsableSerice.Update(responsable, id);
        }

        // DELETE responsable/5
        [HttpDelete("{string}")]
        public void Delete(string id)
        {
            ResponsableService objResponsableSerice = new ResponsableService();
            objResponsableSerice.Delete(id);
        }
    }
}
