using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using Microsoft.IdentityModel.Protocols;
using ToDo.Domain;
using ToDo.Domain.Interfaces;

namespace ToDo.Repositories
{
    class UserRepository : IUserRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["ToDoDbConnection"].ConnectionString;

        public User GetUser(int userId)
        {
            User user = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                user = db.Query<User>("SELECT * FROM Users WHERE Id = @id", new { userId }).FirstOrDefault();
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
            //using (IDbConnection db = new SqlConnection(connectionString))
            //{
            //    var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age); SELECT CAST(SCOPE_IDENTITY() as int)";
            //    int? userId = db.Query<int>(sqlQuery, user).FirstOrDefault();
            //    user.Id = userId;
            //}
            //return user;
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
