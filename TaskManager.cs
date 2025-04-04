using System;
using System.Collections.Generic;
using System.Linq;

namespace IndividualProjectTodo_List
{
    public class TaskManager : ITaskService
    {
        private readonly List<Project> _projects;

        public TaskManager(List<Project> projects)
        {
            _projects = projects;
        }

        public void AddTask()
        {
            var project = UserInputHandler.GetProjectFromUserInput(_projects);
            if (project == null) return;

            var todoList = UserInputHandler.GetTodoListFromUserInput(project);
            if (todoList == null) return;

            var task = UserInputHandler.GetTaskDetailsFromUserInput(project.Name, todoList.Name);
            todoList.AddTask(task);
            Console.WriteLine("Task added successfully.");
        }

        public void EditTask()
        {
            var project = UserInputHandler.GetProjectFromUserInput(_projects);
            if (project == null) return;

            var todoList = UserInputHandler.GetTodoListFromUserInput(project);
            if (todoList == null) return;

            var task = UserInputHandler.GetTaskFromUserInput(todoList);
            if (task == null) return;

            TaskUpdater.UpdateTaskDetailsFromUserInput(task);
            Console.WriteLine("Task edited successfully.");
        }

        public void MarkTaskAsDone()
        {
            var task = UserInputHandler.GetTaskFromUserInput(_projects);
            if (task == null) return;

            task.Status = "Done";
            Console.WriteLine("Task marked as done.");
        }

        public void RemoveTask()
        {
            var task = UserInputHandler.GetTaskFromUserInput(_projects);
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

        public List<Project> GetProjects()
        {
            return _projects;
        }

        private TodoList GetTodoListByName(string projectName, string todoListName)
        {
            var project = _projects.FirstOrDefault(p => p.Name.Equals(projectName, StringComparison.OrdinalIgnoreCase));
            return project?.TodoLists.FirstOrDefault(tl => tl.Name.Equals(todoListName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
