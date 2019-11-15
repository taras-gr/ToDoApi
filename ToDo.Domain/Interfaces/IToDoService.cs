using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Domain
{
    public interface IToDoService
    {
        ToDoItem GetToDo(int userId, int toDoId);
        List<ToDoItem> GetToDos(int userId);
        void AddToDo(int userId, ToDoItem toDoItem);
        void UpdateToDo(int userId, int toDoId, ToDoItem toDoItem);
        void DeleteToDo(int userId, int toDoId);
    }
}
