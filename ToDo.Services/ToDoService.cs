using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Models;

namespace ToDo.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _repository;

        public ToDoService(IToDoRepository repository)
        {
            _repository = repository;
        }
        public async Task AddToDoItem(ToDoItem toDoItem)
        {
            await _repository.AddToDoItem(toDoItem);
        }

        public async Task<bool> DeleteToDoItem(int toDoId)
        {
            return await _repository.DeleteToDoItem(toDoId);
        }

        public async Task<ToDoItem> GetToDoItem(int toDoId)
        {
            return await _repository.GetToDoItem(toDoId);
        }

        public async Task<List<ToDoItem>> GetToDoItems(string userId)
        {
            return await _repository.GetToDoItems(userId);
        }

        public async Task<bool> UpdateToDoItem(int toDoId, ToDoItem toDoItem)
        {
            return await _repository.UpdateToDoItem(toDoId, toDoItem);
        }
    }
}
