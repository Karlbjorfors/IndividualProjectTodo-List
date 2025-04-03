namespace IndividualProjectTodo_List
{
    public class TodoTask : Item
    {
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public string ProjectName { get; set; }
        public string TodoListName { get; set; }

        public TodoTask(string name, string description, DateTime dueDate, string status, string projectName, string todoListName)
            : base(name, description)
        {
            DueDate = dueDate;
            Status = status;
            ProjectName = projectName;
            TodoListName = todoListName;
        }

        public void EditTask(string name, string description, DateTime dueDate, string status)
        {
            EditItem(name, description);
            DueDate = dueDate;
            Status = status;
        }
    }
}
