using System;
using System.Collections.Generic;
using System.Text;
using ToDo.DAL;
using ToDo.Domain;

namespace ToDo.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _repository;

        public ToDoService(IToDoRepository repository)
        {
            _repository = repository;
        }

        public void AddToDo(int userId, ToDoItem toDoItem)
        {
            _repository.AddToDoItem(userId, toDoItem);
        }

        public void DeleteToDo(int userId, int toDoId)
        {
            _repository.DeleteToDoItem(userId, toDoId);
        }

        public ToDoItem GetToDo(int userId, int toDoId)
        {
            return _repository.GetToDoItem(userId, toDoId);
        }

        public List<ToDoItem> GetToDos(int userId)
        {
            return _repository.GetToDoItems(userId);
        }

        public void UpdateToDo(int userId, int toDoId, ToDoItem toDoItem)
        {
            _repository.UpdateToDoItem(userId, toDoId, toDoItem);
        }
    }
}
