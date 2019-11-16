using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using ToDo.Domain;
using ToDo.Domain.Interfaces;

namespace ToDo.Repositories.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private string connectionString = "Data Source=DESKTOP-RUQ7T0V;Initial Catalog=ToDoDb;Integrated Security=True;Pooling=False";

        public ToDoItem GetToDoItem(int toDoId)
        {
            ToDoItem toDoItem;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                toDoItem = db.Query<ToDoItem>("SELECT * FROM ToDoItems WHERE Id = @toDoId", new { toDoId }).FirstOrDefault();
            }
            return toDoItem;
        }

        public List<ToDoItem> GetToDoItems(string userId)
        {
            List<ToDoItem> toDoItems;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                toDoItems = db.Query<ToDoItem>($"SELECT * FROM ToDoItems WHERE UserId = '{userId}'").ToList();
            }
            return toDoItems;
        }

        public void AddToDoItem(ToDoItem toDoItem)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO ToDoItems (Title, Text, IsDone, UserId) VALUES " +
                               $"('{toDoItem.Title}', '{toDoItem.Text}', '{toDoItem.IsDone}', '{toDoItem.UserId}')";
                db.Execute(sqlQuery);
            }
        }

        public void UpdateToDoItem(int toDoId, ToDoItem toDoItem)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = $"UPDATE ToDoItems SET Title = '{toDoItem.Title}', Text = '{toDoItem.Text}', IsDone = '{toDoItem.IsDone}', UserId = '{toDoItem.UserId}' " +
                               $"WHERE Id = '{toDoId}";
                db.Execute(sqlQuery);
            }
        }

        public void DeleteToDoItem(int toDoId)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = $"DELETE FROM ToDoItems WHERE Id = {toDoId}";
                db.Execute(sqlQuery);
            }
        }
    }
}
