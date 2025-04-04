using System.Collections.Generic;

namespace IndividualProjectTodo_List
{
    public class Project : Item
    {
        public string Status { get; set; }
        public List<TodoList> TodoLists { get; set; } = new List<TodoList>();

        public Project(string name, string description, string status)
            : base(name, description)
        {
            Status = status;
        }

        public void AddTodoList(TodoList todoList)
        {
            TodoLists.Add(todoList);
        }

        public void RemoveTodoList(TodoList todoList)
        {
            TodoLists.Remove(todoList);
        }

        public void EditProject(string name, string description, string status)
        {
            EditItem(name, description);
            Status = status;
        }

        public List<TodoList> GetTodoLists()
        {
            return TodoLists;
        }
    }
}
