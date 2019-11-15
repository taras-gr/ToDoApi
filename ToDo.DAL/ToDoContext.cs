using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.DAL
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<ToDoItem> ToDos { get; set; }
    }
}
