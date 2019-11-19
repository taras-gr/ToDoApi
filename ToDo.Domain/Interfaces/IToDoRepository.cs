using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces
{
    public interface IToDoRepository
    {
        Task<ToDoItem> GetToDoItem(int toDoId);
        Task<List<ToDoItem>> GetToDoItems(string userId);
        Task AddToDoItem(ToDoItem toDoItem);
        Task<bool> UpdateToDoItem(int toDoId, ToDoItem toDoItem);
        Task<bool> DeleteToDoItem(int toDoId);
    }
}
