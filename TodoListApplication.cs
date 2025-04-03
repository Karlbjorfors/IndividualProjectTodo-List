using IndividualProjectTodo_List;
using System.Text.Json;
using System.IO;

public class TodoListApplication
{
    public static List<Project> projects = new List<Project>();
    private static IProjectService projectService;
    private static ITaskService taskService;

    public static void Main(string[] args)
    {
        projectService = new ProjectService(projects);
        taskService = new TaskService(projects);

        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tasks.json");
        LoadProjectsFromFile(filePath);
        RunMainMenu(filePath);
    }

    private static void RunMainMenu(string filePath)
    {
        while (true)
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
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    taskService.AddTask();
                    break;
                case "2":
                    taskService.EditTask();
                    break;
                case "3":
                    taskService.MarkTaskAsDone();
                    break;
                case "4":
                    taskService.RemoveTask();
                    break;
                case "5":
                    taskService.ListTasks();
                    break;
                case "6":
                    SaveProjectsToFile(filePath);
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    // Save to file
    public static void SaveProjectsToFile(string filePath)
    {
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(projects, options);
            File.WriteAllText(filePath, jsonString);
            Console.WriteLine("Projects saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving projects to file: {ex.Message}");
            LogError(ex);
        }
    }

    // Load from file
    public static void LoadProjectsFromFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                projects = JsonSerializer.Deserialize<List<Project>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Project>();
                Console.WriteLine("Projects loaded successfully.");
            }
            else
            {
                projects = new List<Project>();
                Console.WriteLine("No existing projects file found. Starting with an empty list.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading projects from file: {ex.Message}");
            LogError(ex);
            projects = new List<Project>(); // Ensure projects is initialized
        }
    }

    // Log error to a file
    private static void LogError(Exception ex)
    {
        string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error.log");
        try
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {ex.Message}");
                writer.WriteLine(ex.StackTrace);
            }
        }
        catch
        {
            Console.WriteLine("Failed to write to log file.");
        }
    }
}
