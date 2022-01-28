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
    [Route("api/prioritat")]
    [ApiController]
    public class PrioritatController : ControllerBase
    {
        // GET prioritat
        [HttpGet]
        public List<Prioritat> Get()
        {
            PrioritatService objPrioritatSerice = new PrioritatService();
            return objPrioritatSerice.GetAll();
        }

        // GET prioritat/1
        [HttpGet("id/{id}")]
        public Prioritat Get(string id)
        {
            PrioritatService objPrioritatSerice = new PrioritatService();
            return objPrioritatSerice.GetOne(id);
        }

        // POST prioritat
        [HttpPost]
        public void Post([FromBody] Prioritat prioritat)
        {
            PrioritatService objPrioritatSerice = new PrioritatService();
            objPrioritatSerice.Add(prioritat);
        }

        // PUT prioritat/5
        [HttpPut("id/{id}")]
        public void Put(string id, [FromBodyAttribute] Prioritat prioritat)
        {
            PrioritatService objPrioritatSerice = new PrioritatService();
            objPrioritatSerice.Update(prioritat, id);
        }

        /*
        // PUT prioritat/5
        [HttpPut("{string}")]
        public void Put([FromRouteAttribute] string id, [FromBodyAttribute] Prioritat prioritat)
        {
            PrioritatService objPrioritatSerice = new PrioritatService();
            objPrioritatSerice.Update(prioritat);
        }*/

        // DELETE prioritat/5
        [HttpDelete("{string}")]
        public void Delete(string id)
        {
            PrioritatService objPrioritatSerice = new PrioritatService();
            objPrioritatSerice.Delete(id);
        }
    }
}
