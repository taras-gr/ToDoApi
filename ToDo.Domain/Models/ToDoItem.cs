namespace ToDo.Domain
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool IsDone { get; set; }
    }
}