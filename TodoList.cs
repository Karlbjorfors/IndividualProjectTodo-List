using System.Collections.Generic;

namespace IndividualProjectTodo_List
{
    public class TodoList : Item
    {
        public string ProjectName { get; set; }
        public List<TodoTask> Tasks { get; set; } = new List<TodoTask>();

        public TodoList(string name, string description, string projectName)
            : base(name, description)
        {
            ProjectName = projectName;
        }

        public void AddTask(TodoTask task)
        {
            Tasks.Add(task);
        }

        public void RemoveTask(TodoTask task)
        {
            Tasks.Remove(task);
        }

        public void EditTodoList(string name, string description)
        {
            EditItem(name, description);
        }

        public List<TodoTask> GetTasks()
        {
            return Tasks;
        }
    }
}
