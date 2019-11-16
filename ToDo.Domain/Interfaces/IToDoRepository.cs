using System.Collections.Generic;

namespace ToDo.Domain.Interfaces
{
    public interface IToDoRepository
    {
        ToDoItem GetToDoItem(int toDoId);
        List<ToDoItem> GetToDoItems(string userId);
        void AddToDoItem(ToDoItem toDoItem);
        void UpdateToDoItem(int toDoId, ToDoItem toDoItem);
        void DeleteToDoItem(int toDoId);
    }
}
