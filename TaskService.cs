using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace IndividualProjectTodo_List
{
    public class TaskService : ITaskService
    {
        private List<Project> _projects;
        private const string FilePath = "tasks.json";

        public TaskService()
        {
            _projects = new List<Project>();
        }

        public void AddTask()
        {
            var todoList = GetTodoListFromUserInput();
            if (todoList == null) return;

            var task = GetTaskDetailsFromUserInput(todoList.ProjectName, todoList.Name);
            todoList.AddTask(task);
            Console.WriteLine("Task added successfully.");
        }

        public void EditTask()
        {
            var task = GetTaskFromUserInput();
            if (task == null) return;

            UpdateTaskDetailsFromUserInput(task);
            Console.WriteLine("Task edited successfully.");
        }

        public void MarkTaskAsDone()
        {
            var task = GetTaskFromUserInput();
            if (task == null) return;

            task.Status = "Done";
            Console.WriteLine("Task marked as done.");
        }

        public void RemoveTask()
        {
            var task = GetTaskFromUserInput();
            if (task == null) return;

            var todoList = GetTodoListByName(task.ProjectName, task.TodoListName);
            todoList.RemoveTask(task);
            Console.WriteLine("Task removed successfully.");
        }

        public void ListTasks()
        {
            foreach (var project in _projects)
            {
                Console.WriteLine($"Project: {project.Name}");
                foreach (var todoList in project.TodoLists)
                {
                    Console.WriteLine($"\tTodo List: {todoList.Name}");
                    foreach (var task in todoList.Tasks)
                    {
                        Console.WriteLine($"\t\tTask: {task.Name}, Due: {task.DueDate}, Status: {task.Status}");
                    }
                }
            }
        }

        public void AddProject()
        {
            var project = GetProjectDetailsFromUserInput();
            _projects.Add(project);
            Console.WriteLine("Project added successfully.");
        }

        public void EditProject()
        {
            var project = GetProjectFromUserInput();
            if (project == null) return;

            var updatedProject = GetProjectDetailsFromUserInput();
            project.EditProject(updatedProject.Name, updatedProject.Description, updatedProject.Status);
            Console.WriteLine("Project edited successfully.");
        }

        public void RemoveProject()
        {
            var project = GetProjectFromUserInput();
            if (project == null) return;

            _projects.Remove(project);
            Console.WriteLine("Project removed successfully.");
        }

        public void SaveProjectsToFile()
        {
            var json = JsonSerializer.Serialize(_projects);
            File.WriteAllText(FilePath, json);
        }

        public void LoadProjectsFromFile()
        {
            if (!File.Exists(FilePath))
            {
                _projects = new List<Project>();
                return;
            }

            var json = File.ReadAllText(FilePath);
            _projects = JsonSerializer.Deserialize<List<Project>>(json);
        }

        private Project GetProjectFromUserInput()
        {
            Console.WriteLine("Enter project name:");
            string projectName = Console.ReadLine();
            var project = GetProjectByName(projectName);

            if (project == null)
            {
                Console.WriteLine("Project not found.");
            }

            return project;
        }

        private TodoList GetTodoListFromUserInput()
        {
            var project = GetProjectFromUserInput();
            if (project == null) return null;

            Console.WriteLine("Enter todo list name:");
            string todoListName = Console.ReadLine();
            var todoList = GetTodoListByName(project, todoListName);

            if (todoList == null)
            {
                Console.WriteLine("Todo list not found.");
            }

            return todoList;
        }

        private TodoTask GetTaskFromUserInput()
        {
            var todoList = GetTodoListFromUserInput();
            if (todoList == null) return null;

            Console.WriteLine("Enter task name:");
            string taskName = Console.ReadLine();
            var task = GetTaskByName(todoList, taskName);

            if (task == null)
            {
                Console.WriteLine("Task not found.");
            }

            return task;
        }

        private Project GetProjectDetailsFromUserInput()
        {
            Console.WriteLine("Enter project name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter project description:");
            string description = Console.ReadLine();
            Console.WriteLine("Enter project status:");
            string status = Console.ReadLine();

            return new Project(name, description, status);
        }

        private TodoTask GetTaskDetailsFromUserInput(string projectName, string todoListName)
        {
            Console.WriteLine("Enter task name:");
            string taskName = Console.ReadLine();
            Console.WriteLine("Enter task description:");
            string taskDescription = Console.ReadLine();
            Console.WriteLine("Enter due date (yyyy-MM-dd):");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter task status:");
            string taskStatus = Console.ReadLine();

            return new TodoTask(taskName, taskDescription, dueDate, taskStatus, projectName, todoListName);
        }

        private void UpdateTaskDetailsFromUserInput(TodoTask task)
        {
            Console.WriteLine("Enter new task description:");
            string taskDescription = Console.ReadLine();
            Console.WriteLine("Enter new due date (yyyy-MM-dd):");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter new task status:");
            string taskStatus = Console.ReadLine();

            task.EditTask(task.Name, taskDescription, dueDate, taskStatus);
        }

        private Project GetProjectByName(string projectName)
        {
            return _projects.FirstOrDefault(p => p.Name.Equals(projectName, StringComparison.OrdinalIgnoreCase));
        }

        private TodoList GetTodoListByName(Project project, string todoListName)
        {
            return project.TodoLists.FirstOrDefault(tl => tl.Name.Equals(todoListName, StringComparison.OrdinalIgnoreCase));
        }

        private TodoList GetTodoListByName(string projectName, string todoListName)
        {
            var project = GetProjectByName(projectName);
            return project?.TodoLists.FirstOrDefault(tl => tl.Name.Equals(todoListName, StringComparison.OrdinalIgnoreCase));
        }

        private TodoTask GetTaskByName(TodoList todoList, string taskName)
        {
            return todoList.Tasks.FirstOrDefault(t => t.Name.Equals(taskName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
