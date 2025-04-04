using System;
using System.Collections.Generic;

namespace IndividualProjectTodo_List
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var taskService = new TaskService();
            taskService.LoadProjectsFromFile();

            while (true)
            {
                ShowMenu();
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        taskService.ListTasks();
                        break;
                    case "2":
                        taskService.AddTask();
                        break;
                    case "3":
                        EditTaskMenu(taskService);
                        break;
                    case "4":
                        taskService.SaveProjectsToFile();
                        Console.WriteLine("Tasks saved. Goodbye!");
                        return;
                    case "5":
                        taskService.AddProject();
                        break;
                    case "6":
                        taskService.EditProject();
                        break;
                    case "7":
                        taskService.RemoveProject();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine(">> Welcome to ToDoLy");
            Console.WriteLine(">> You have X tasks todo and Y tasks are done!");
            Console.WriteLine(">> Pick an option:");
            Console.WriteLine("(1) Show Task List (by date or project)");
            Console.WriteLine("(2) Add New Task");
            Console.WriteLine("(3) Edit Task (update, mark as done, remove)");
            Console.WriteLine("(4) Save and Quit");
            Console.WriteLine("(5) Add New Project");
            Console.WriteLine("(6) Edit Project");
            Console.WriteLine("(7) Remove Project");
        }

        private static void EditTaskMenu(TaskService taskService)
        {
            Console.WriteLine("(1) Edit Task");
            Console.WriteLine("(2) Mark Task as Done");
            Console.WriteLine("(3) Remove Task");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    taskService.EditTask();
                    break;
                case "2":
                    taskService.MarkTaskAsDone();
                    break;
                case "3":
                    taskService.RemoveTask();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
