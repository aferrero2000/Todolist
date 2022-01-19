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
        public Prioritat Get(ObjectId id)
        {
            PrioritatService objPrioritatSerice = new PrioritatService();
            return objPrioritatSerice.GetOne(id);
        }

        // GET prioritat/1
        [HttpGet("color/{color}")]
        public Prioritat Get(string color)
        {
            PrioritatService objPrioritatSerice = new PrioritatService();
            return objPrioritatSerice.GetOne(color);
        }

        // POST prioritat
        [HttpPost]
        public void Post([FromBody] Prioritat prioritat)
        {
            PrioritatService objPrioritatSerice = new PrioritatService();
            objPrioritatSerice.Add(prioritat);
        }

        // PUT prioritat/5
        [HttpPut("{ObjectId}")]
        public void Put(ObjectId id, [FromBody] Prioritat prioritat)
        {
            PrioritatService objPrioritatSerice = new PrioritatService();
            objPrioritatSerice.Update(prioritat);
        }

        // DELETE prioritat/5
        [HttpDelete("{ObjectId}")]
        public void Delete(ObjectId id)
        {
            PrioritatService objPrioritatSerice = new PrioritatService();
            objPrioritatSerice.Delete(id);
        }
    }
}
