using System;
using System.Collections.Generic;
using System.Linq;

namespace IndividualProjectTodo_List
{
    public static class UserInputHandler
    {
        public static Project GetProjectFromUserInput(List<Project> projects)
        {
            Console.WriteLine("Enter project name:");
            string projectName = Console.ReadLine();
            var project = projects.FirstOrDefault(p => p.Name.Equals(projectName, StringComparison.OrdinalIgnoreCase));

            if (project == null)
            {
                Console.WriteLine("Project not found.");
            }

            return project;
        }

        public static TodoList GetTodoListFromUserInput(Project project)
        {
            Console.WriteLine("Enter todo list name:");
            string todoListName = Console.ReadLine();
            var todoList = project.TodoLists.FirstOrDefault(tl => tl.Name.Equals(todoListName, StringComparison.OrdinalIgnoreCase));

            if (todoList == null)
            {
                Console.WriteLine("Todo list not found.");
            }

            return todoList;
        }

        public static TodoTask GetTaskFromUserInput(List<Project> projects)
        {
            var project = GetProjectFromUserInput(projects);
            if (project == null) return null;

            var todoList = GetTodoListFromUserInput(project);
            if (todoList == null) return null;

            return GetTaskFromUserInput(todoList);
        }

        public static TodoTask GetTaskFromUserInput(TodoList todoList)
        {
            Console.WriteLine("Enter task name:");
            string taskName = Console.ReadLine();
            var task = todoList.Tasks.FirstOrDefault(t => t.Name.Equals(taskName, StringComparison.OrdinalIgnoreCase));

            if (task == null)
            {
                Console.WriteLine("Task not found.");
            }

            return task;
        }

        public static TodoTask GetTaskDetailsFromUserInput(string projectName, string todoListName)
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
    }
}
