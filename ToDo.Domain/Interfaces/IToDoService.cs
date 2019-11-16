using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Domain
{
    public interface IToDoService
    {
        ToDoItem GetToDo(int toDoId);
        List<ToDoItem> GetToDos(int userId);
        void AddToDo(ToDoItem toDoItem);
        void UpdateToDo(int toDoId, ToDoItem toDoItem);
        void DeleteToDo(int toDoId);
    }
}
