using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Domain;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Models;
using ToDoApi.DTOs;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        public ToDoItemController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ToDoItem>>> GetToDoItem()
        {
            try
            {
                string userIdFromUserManager = User.Claims.First(c => c.Type == "UserID").Value;

                var toDoItems = await _toDoService.GetToDoItems(userIdFromUserManager);

                return toDoItems;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody]ToDoItemCreateDto toDoItem)
        {
            string userIdFromUserManager = User.Claims.First(c => c.Type == "UserID").Value;

            var toDoItemToCreate = new ToDoItem
            {
                Text = toDoItem.Text,
                Title = toDoItem.Title,
                IsDone = toDoItem.IsDone,
                UserId = userIdFromUserManager
            };

            _toDoService.AddToDoItem(toDoItemToCreate);

            return NoContent();
        }
    }
}