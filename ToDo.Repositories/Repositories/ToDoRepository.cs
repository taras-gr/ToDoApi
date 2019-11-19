using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain;
using ToDo.Domain.Classes;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Models;

namespace ToDo.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoDbContext _context;

        public ToDoRepository(IOptions<Settings> settings)
        {
            _context = new ToDoDbContext(settings);
        }

        public async Task AddToDoItem(ToDoItem toDoItem)
        {
            try
            {
                await _context.ToDoItems.InsertOneAsync(toDoItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteToDoItem(int toDoId)
        {
            try
            {
                DeleteResult actionResult = await _context.ToDoItems.DeleteOneAsync(Builders<ToDoItem>.Filter.Eq("Id", toDoId));

                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ToDoItem> GetToDoItem(int toDoId)
        {
            try
            {
                return await _context.ToDoItems.Find(toDoItem => toDoItem.Id == toDoId).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ToDoItem>> GetToDoItems(string userId)
        {
            try
            {
                return await _context.ToDoItems.Find(toDoItem => toDoItem.UserId == userId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateToDoItem(int toDoId, ToDoItem toDoItem)
        {
            try
            {
                ReplaceOneResult actionResult = await _context.ToDoItems.ReplaceOneAsync(n => n.Id.Equals(toDoId),
                                                                                            toDoItem,
                                                                                            new UpdateOptions { IsUpsert = true });

                return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
