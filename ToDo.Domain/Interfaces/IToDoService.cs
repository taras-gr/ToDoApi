using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Models;

namespace ToDo.Domain
{
    public interface IToDoService
    {
        Task<ToDoItem> GetToDoItem(int toDoId);
        Task<List<ToDoItem>> GetToDoItems(string userId);
        Task AddToDoItem(ToDoItem toDoItem);
        Task<bool> UpdateToDoItem(int toDoId, ToDoItem toDoItem);
        Task<bool> DeleteToDoItem(int toDoId);
    }
}
