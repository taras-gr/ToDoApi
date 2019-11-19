using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByName(string userName);
        Task<List<User>> GetUsers();
        Task AddUser(User user);
        Task<bool> UpdateUser(string userName, User user);
        Task<bool> DeleteUser(string userName);
    }
}
