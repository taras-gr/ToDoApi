using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Services;

namespace ToDoApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private ToDoService _toDoService;
        //public GetToDo(int userId, int toDoId)
        //{
        //    _toDoService
        //}
    }
}