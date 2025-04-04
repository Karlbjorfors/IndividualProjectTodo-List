using System;
using System.Collections.Generic;
using IndividualProjectTodo_List;

public class CommandLineInterface
{
    private readonly TaskService _taskService;
    private readonly FileService _fileService;
    private const string FilePath = "tasks.json";

    public CommandLineInterface(TaskService taskService, FileService fileService)
    {
        _taskService = taskService;
        _fileService = fileService;
    }

    public void ShowMenu()
    {
        Console.WriteLine(">> Welcome to ToDoLy");
        Console.WriteLine(">> You have X tasks todo and Y tasks are done!");
        Console.WriteLine(">> Pick an option:");
        Console.WriteLine("(1) Show Task List (by date or project)");
        Console.WriteLine("(2) Add New Task");
        Console.WriteLine("(3) Edit Task (update, mark as done, remove)");
        Console.WriteLine("(4) Save and Quit");
    }

    public void HandleUserInput()
    {
        while (true)
        {
            ShowMenu();
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayTasks(_taskService.GetProjects());
                    break;
                case "2":
                    _taskService.AddTask();
                    break;
                case "3":
                    EditTaskMenu();
                    break;
                case "4":
                    SaveAndQuit();
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private void DisplayTasks(List<Project> projects)
    {
        _taskService.ListTasks();
    }

    private void EditTaskMenu()
    {
        Console.WriteLine("(1) Edit Task");
        Console.WriteLine("(2) Mark Task as Done");
        Console.WriteLine("(3) Remove Task");
        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                _taskService.EditTask();
                break;
            case "2":
                _taskService.MarkTaskAsDone();
                break;
            case "3":
                _taskService.RemoveTask();
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }

    private void SaveAndQuit()
    {
        _fileService.SaveProjectsToFile(_taskService.GetProjects(), FilePath);
        Console.WriteLine("Tasks saved. Goodbye!");
    }
}
