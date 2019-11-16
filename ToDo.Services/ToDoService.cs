using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Domain;
using ToDo.Domain.Interfaces;

namespace ToDo.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _repository;

        public ToDoService(IToDoRepository repository)
        {
            _repository = repository;
        }

        public void AddToDo(ToDoItem toDoItem)
        {
            _repository.AddToDoItem(toDoItem);
        }

        public void DeleteToDo(int toDoId)
        {
            _repository.DeleteToDoItem(toDoId);
        }

        public ToDoItem GetToDo(int toDoId)
        {
            return _repository.GetToDoItem(toDoId);
        }

        public List<ToDoItem> GetToDos(int userId)
        {
            throw new NotImplementedException();
        }

        public void UpdateToDo(int toDoId, ToDoItem toDoItem)
        {
            _repository.UpdateToDoItem(toDoId, toDoItem);
        }
    }
}
