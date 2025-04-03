using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectTodo_List
{
    
public class TaskService : ITaskService
    {
        private readonly List<Project> projects;

        public TaskService(List<Project> projects)
        {
            this.projects = projects;
        }

        public void AddTask()
        {
            var (title, description, dueDate, projectName) = GetTaskDetailsFromUser();
            var task = new TodoTask(title, description, dueDate, "Pending", projectName, projectName);
            var project = GetOrCreateProject(projectName);
            var todoList = GetOrCreateTodoList(project, projectName);
            todoList.AddTask(task);
        }

        public void EditTask()
        {
            var (project, todoList, task) = GetTaskFromUser();
            if (task == null) return;

            var (newTitle, newDescription, newDueDate, newStatus) = GetTaskDetailsFromUser();
            task.EditTask(newTitle, newDescription, newDueDate, newStatus);
            Console.WriteLine("Task updated successfully.");
        }

        public void MarkTaskAsDone()
        {
            var (project, todoList, task) = GetTaskFromUser();
            if (task == null) return;

            task.Status = "Done";
            Console.WriteLine("Task marked as done.");
        }

        public void RemoveTask()
        {
            var (project, todoList, task) = GetTaskFromUser();
            if (task == null) return;

            todoList.RemoveTask(task);
            Console.WriteLine("Task removed successfully.");
        }

        public void ListTasks()
        {
            Console.WriteLine("1. Sort by Date");
            Console.WriteLine("2. Sort by Project");
            Console.Write("Choose an option: ");
            var choice = Console.ReadLine();

            List<TodoTask> tasks = GetAllTasks();

            switch (choice)
            {
                case "1":
                    tasks = tasks.OrderBy(t => t.DueDate).ToList();
                    break;
                case "2":
                    tasks = tasks.OrderBy(t => t.ProjectName).ToList();
                    break;
                default:
                    Console.WriteLine("Invalid option. Listing unsorted tasks.");
                    break;
            }

            foreach (var task in tasks)
            {
                string colorCode;
                string statusMessage = task.Status;

                if (task.Status == "Done")
                {
                    colorCode = "\u001b[32m"; // Green
                }
                else if (task.DueDate < DateTime.Now.Date)
                {
                    colorCode = "\u001b[31m"; // Red
                    statusMessage = "Too Late";
                }
                else
                {
                    colorCode = "\u001b[33m"; // Yellow
                }

                Console.WriteLine($"{colorCode}{task.Name} - {task.Description} - {task.DueDate.ToShortDateString()} - {statusMessage} - {task.ProjectName}\u001b[0m");
            }
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        // Helper Methods
        private static (string title, string description, DateTime dueDate, string projectName) GetTaskDetailsFromUser()
        {
            Console.Write("Enter task title: ");
            string title = Console.ReadLine();
            Console.Write("Enter task description: ");
            string description = Console.ReadLine();
            Console.Write("Enter due date (yyyy-mm-dd): ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter project name: ");
            string projectName = Console.ReadLine();
            return (title, description, dueDate, projectName);
        }

        private Project GetOrCreateProject(string projectName)
        {
            var project = projects.FirstOrDefault(p => p.Name == projectName);
            if (project == null)
            {
                project = new Project(projectName, "", "Active");
                projects.Add(project);
            }
            return project;
        }

        private TodoList GetOrCreateTodoList(Project project, string todoListName)
        {
            var todoList = project.TodoLists.FirstOrDefault(t => t.Name == todoListName);
            if (todoList == null)
            {
                todoList = new TodoList(todoListName, "", project.Name);
                project.AddTodoList(todoList);
            }
            return todoList;
        }

        private (Project project, TodoList todoList, TodoTask task) GetTaskFromUser()
        {
            Console.Write("Enter the project name of the task: ");
            string projectName = Console.ReadLine();
            var project = projects.FirstOrDefault(p => p.Name == projectName);
            if (project == null)
            {
                Console.WriteLine("Project not found.");
                return (null, null, null);
            }

            Console.Write("Enter the task title: ");
            string taskTitle = Console.ReadLine();
            var todoList = project.TodoLists.FirstOrDefault(t => t.Tasks.Any(task => task.Name == taskTitle));
            if (todoList == null)
            {
                Console.WriteLine("Task not found.");
                return (null, null, null);
            }

            var task = todoList.Tasks.FirstOrDefault(t => t.Name == taskTitle);
            if (task == null)
            {
                Console.WriteLine("Task not found.");
                return (null, null, null);
            }

            return (project, todoList, task);
        }

        private List<TodoTask> GetAllTasks()
        {
            List<TodoTask> tasks = new List<TodoTask>();
            foreach (var project in projects)
            {
                foreach (var todoList in project.TodoLists)
                {
                    tasks.AddRange(todoList.GetTasks());
                }
            }
            return tasks;
        }
    }

}
