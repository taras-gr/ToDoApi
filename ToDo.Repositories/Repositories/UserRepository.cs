using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using ToDo.Domain;
using ToDo.Domain.Interfaces;

namespace ToDo.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string connectionString = "Data Source=DESKTOP-RUQ7T0V;Initial Catalog=ToDoDb;Integrated Security=True;Pooling=False";

        public User GetUser(int userId)
        {
            User user = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                user = db.Query<User>("SELECT * FROM Users WHERE Id = @userId", new { userId }).FirstOrDefault();
            }
            return user;
        }

        public List<User> GetUsers()
        {
            List<User> users = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                users = db.Query<User>("SELECT * FROM Users").ToList();
            }
            return users;
        }

        public void AddUser(User user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = $"INSERT INTO Users (Name, FullName, Email) VALUES ('{user.Name}', '{user.FullName}', '{user.Email}')";
                db.Execute(sqlQuery);
            }
        }

        public void UpdateUser(int userId, User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
