using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Service;
using WebApi.Model;


namespace WebApi.Controllers
{
    /*[Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: users
        [HttpGet]
        public List<User> Get()
        {
            UserService objUserService = new UserService();
            return objUserService.GetAll();
        }

        // GET users/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            UserService objUserService = new UserService();
            return objUserService.GetById(id);
        }

        // POST users
        [HttpPost]
        public void Post([FromBody] User user)
        {
            UserService objUserService = new UserService();
            objUserService.Add(user);
        }

        // PUT users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User user)
        {
            UserService objUserService = new UserService();
            objUserService.Update(user);
        }

        // DELETE users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            UserService objUserService = new UserService();
            objUserService.Delete(id);
        }
    }
    */
}
