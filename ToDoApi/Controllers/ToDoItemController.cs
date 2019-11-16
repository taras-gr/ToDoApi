using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Domain;
using ToDo.Domain.Interfaces;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        private readonly IToDoRepository _repository;

        public ToDoItemController(IToDoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{userId}")]
        public IActionResult Get(string userId)
        {
            var toDoItems = _repository.GetToDoItems(userId);

            return Ok(toDoItems);
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            //_repository.AddUser(user);

            return NoContent();
        }
    }
}