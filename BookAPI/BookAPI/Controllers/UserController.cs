using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BookAPI.Models;
using BookAPI.Repositories;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserRepository userRepository;
        public UserController(UserRepository userrepository)
        {
            userRepository = userrepository;
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return userRepository.ReadAll();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public User Get(Guid id)
        {
            return userRepository.Read(id);
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] User user)
        {
            userRepository.Create(user);
        }

        [HttpPut]
        public void Put([FromBody] User user)
        {
            userRepository.Update(user);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            userRepository.Delete(id);
        }
    }
}
