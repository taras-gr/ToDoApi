using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDo.DAL;
using ToDo.Domain;

namespace ToDo.Repositories
{
    class ToDoRepository : IToDoRepository
    {
        private readonly ToDoContext _context;
        public ToDoRepository(ToDoContext context)
        {
            _context = context;
        }
        public void AddToDoItem(int userId, ToDoItem toDoItem)
        {
            if (toDoItem == null)
            {
                throw new Exception("ToDo to post is null");
            }

            var user = _context.Users.FirstOrDefault(p => p.Id == userId);

            if (user == null)
            {
                throw new Exception($"User with id: {userId} does not exist");
            }

            var usersToDoItems = user.ToDos;

            usersToDoItems.Add(toDoItem);
        }

        public void DeleteToDoItem(int userId, int toDoId)
        {
            var user = _context.Users.FirstOrDefault(p => p.Id == userId);

            if (user == null)
            {
                throw new Exception($"User with id: {userId} does not exist");
            }

            var toDoToDelete = user.ToDos.FirstOrDefault(p => p.Id == toDoId);

            if (toDoToDelete == null)
            {
                throw new Exception($"ToDo with id: {toDoId} does not exits in user with id: {userId}");
            }

            user.ToDos.Remove(toDoToDelete);
        }

        public ToDoItem GetToDoItem(int userId, int toDoId)
        {
            var user = _context.Users.FirstOrDefault(p => p.Id == userId);

            if (user == null)
            {
                throw new Exception($"User with id: {userId} does not exist");
            }

            var toDoToItem = user.ToDos.FirstOrDefault(p => p.Id == toDoId);

            if (toDoToItem == null)
            {
                throw new Exception($"ToDo with id: {toDoId} does not exits in user with id: {userId}");
            }

            return toDoToItem;
        }

        public List<ToDoItem> GetToDoItems(int userId)
        {
            var user = _context.Users.FirstOrDefault(p => p.Id == userId);

            if (user == null)
            {
                throw new Exception($"User with id: {userId} does not exist");
            }

            var userToDos = user.ToDos;

            if (userToDos == null)
            {
                throw new Exception($"User with id: {userId} does not have todos");
            }

            return userToDos;
        }

        public void UpdateToDoItem(int userId, int toDoId, ToDoItem toDoItem)
        {
            var user = _context.Users.FirstOrDefault(p => p.Id == userId);

            if (user == null)
            {
                throw new Exception($"User with id: {userId} does not exist");
            }

            var toDoToItem = user.ToDos.FirstOrDefault(p => p.Id == toDoId);

            if (toDoToItem == null)
            {
                throw new Exception($"ToDo with id: {toDoId} does not exits in user with id: {userId}");
            }

            if (toDoToItem == null)
            {
                throw new Exception("ToDoItem can not be null");
            }

            toDoToItem = toDoItem;
        }
    }
}
