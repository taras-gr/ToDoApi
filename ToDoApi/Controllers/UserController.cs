using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Domain;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Models;

namespace ToDo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _repository.GetUsers();

            return Ok(users);
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            _repository.AddUser(user);

            return NoContent();
        }
    }
}