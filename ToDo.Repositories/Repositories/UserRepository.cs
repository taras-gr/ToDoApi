using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using ToDo.Domain;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Classes;
using ToDo.Domain.Models;

namespace ToDo.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ToDoDbContext _context;

        public UserRepository(IOptions<Settings> settings)
        {
            _context = new ToDoDbContext(settings);
        }

        public async Task AddUser(User user)
        {
            try
            {
                await _context.Users.InsertOneAsync(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteUser(string userName)
        {
            try
            {
                DeleteResult actionResult = await _context.Users.DeleteOneAsync(Builders<User>.Filter.Eq("Name", userName));

                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetUserByName(string userName)
        {
            try
            {
                return await _context.Users.Find(user => user.Name == userName).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<User>> GetUsers()
        {
            try
            {
                return await _context.Users.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateUser(string userName, User user)
        {
            try
            {
                ReplaceOneResult actionResult = await _context.Users.ReplaceOneAsync(n => n.Name.Equals(userName),
                                                                                        user,
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
