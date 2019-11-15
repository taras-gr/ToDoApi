using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Domain.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(int userId);
        List<User> GetUsers();
        void AddUser(User user);
        void UpdateUser(int userId, User user);
        void DeleteUser(int userId);
    }
}
