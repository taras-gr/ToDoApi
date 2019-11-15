using System.Collections.Generic;

namespace ToDo.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<ToDoItem> ToDos { get; set; }
    }
}