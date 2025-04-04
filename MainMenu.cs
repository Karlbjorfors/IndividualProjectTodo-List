using System;

namespace IndividualProjectTodo_List
{
    public class MainMenu
    {
        private readonly ITaskService _taskService;
        private readonly IFileService _fileService;
        private readonly IErrorLogger _errorLogger;
        private readonly string _filePath;

        public MainMenu(ITaskService taskService, IFileService fileService, IErrorLogger errorLogger, string filePath)
        {
            _taskService = taskService;
            _fileService = fileService;
            _errorLogger = errorLogger;
            _filePath = filePath;
        }

        public void Run()
        {
            while (true)
            {
                Display();
                string choice = GetUserChoice();
                if (HandleChoice(choice))
                {
                    break;
                }
            }
        }

        private void Display()
        {
            Console.Clear();
            Console.WriteLine("Todo List Application");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Edit Task");
            Console.WriteLine("3. Mark Task as Done");
            Console.WriteLine("4. Remove Task");
            Console.WriteLine("5. List Tasks");
            Console.WriteLine("6. Save and Quit");
            Console.Write("Choose an option: ");
        }

        private string GetUserChoice()
        {
            return Console.ReadLine();
        }

        private bool HandleChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    _taskService.AddTask();
                    return false;
                case "2":
                    _taskService.EditTask();
                    return false;
                case "3":
                    _taskService.MarkTaskAsDone();
                    return false;
                case "4":
                    _taskService.RemoveTask();
                    return false;
                case "5":
                    _taskService.ListTasks();
                    return false;
                case "6":
                    SaveAndQuit();
                    return true;
                default:
                    DisplayInvalidOptionMessage();
                    return false;
            }
        }

        private void SaveAndQuit()
        {
            try
            {
                _fileService.SaveToFile(_filePath, _taskService.GetProjects());
                Console.WriteLine("Projects saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving projects to file: {ex.Message}");
                _errorLogger.LogError(ex);
            }
            Environment.Exit(0);
        }

        private void DisplayInvalidOptionMessage()
        {
            Console.WriteLine("Invalid option. Please try again.");
        }
    }
}
