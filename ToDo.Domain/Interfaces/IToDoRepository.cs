using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Domain
{
    public interface IToDoRepository
    {
        ToDoItem GetToDoItem(int userId, int toDoId);
        List<ToDoItem> GetToDoItems(int userId);
        void AddToDoItem(int userId, ToDoItem toDoItem);
        void UpdateToDoItem(int userId, int toDoId, ToDoItem toDoItem);
        void DeleteToDoItem(int userId, int toDoId);
    }
}
