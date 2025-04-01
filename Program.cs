//TodoList Application

//Functions
/* create a project
 * add a todoList to a project
 * add Tasks to a todoList
 * update a project, todoList, task
 * remove a project, todoList, task
 * save project(s) to a .json/txt file
 * Quit
 */

//List of Projects

//create a Project class -Manages TodoLists
/*name, description, status
 *1.Create a project
 *2.Remove a project
 *3.Edit Project
 *4.List Projects~ getProjects()
*/
using System.Text.Json;

public abstract class Item
{
    public string Name { get; set; }
    public string Description { get; set; }
    protected Item(string name, string description)
    {
        Name = name;
        Description = description;
    }
    public void EditItem(string name, string description)
    {
        Name = name;
        Description = description;
    }
}


public class Project : Item
{
    public string status { get; set; }
    public List<TodoList> todoList { get; set; } = new List<TodoList>();
    public Project(string name, string description, string status)
        : base(name, description)
    {
        Status = status;
    }        
    public void AddTodoList(TodoList todoList)
    {
        Todolist.Add(todoList);
    }
    public void RemoveTodoList(TodoList todoList)
    {
        TodoList.Remove(todoList);
    }
    /*public void EditProject(string name, string description, string status)
   
    {
    Name = name;
    Description = description;
    Status = status;
    }
    */
    public List<TodoList> GetTodoLists()
    {
    return TodoLists;
    }
}

//create a TodoList class- manages TodoTasks
/*1.Create a TodoList in a project
 * name, description, projectName
 *2.Remove a TodoList
 *3.Edit TodoList
 *4.List TodoLists~ getTodoLists()
*/
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

    public List<TodoTask> GetTasks()
    {
        return Tasks;
    }
}

//Add a TodoTask class- Repreesents individual tasks
/*1.Create a Task in a TodoList
 * name, description, dueDate, status, projectName, todoListName
 *2.Edit Task
 *3.Remove Task
 *4.List TodoTasks~ getTodoTasks()
*/
public class TodoTask : Item
{
    public DateTime DueDate { get; set; }
    public string Status { get; set; }
    public string ProjectName { get; set; }
    public string TodoListName { get; set; }

    public TodoTask(string name, string description, DateTime dueDate, string status, string projectName, string todoListName)
        : base(name, description)
    {
        DueDate = dueDate;
        Status = status;
        ProjectName = projectName;
        TodoListName = todoListName;
    }

    public void EditTask(string name, string description, DateTime dueDate, string status)
    {
        EditItem(name, description);
        DueDate = dueDate;
        Status = status;
    }
}

//create a Program class- Manages Projects
/*Contains main logic and manages projects
 * 
 */
public class Program
{
    public static List<Project> projects = new List<Project>();

    public static void Main(string[] args)
    {
        // Main logic
    }

    public static void CreateProject(string name, string description, string status)
    {
        var project = new Project(name, description, status);
        projects.Add(project);
    }

    public static void RemoveProject(Project project)
    {
        projects.Remove(project);
    }

    public static void EditProject(Project project, string name, string description, string status)
    {
        project.EditItem(name, description);
        project.Status = status;
    }

    public static List<Project> GetProjects()
    {
        return projects;
    }
    //Save to file
    public static void SaveProjectsToFile(string filePath)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(projects, options);
        File.WriteAllText(filePath, jsonString);
    }
    //Load from file
    public static void LoadProjectsFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            projects = JsonSerializer.Deserialize<List<Project>>(jsonString) ?? new List<Project>();
        }
        else
        {
            projects = new List<Project>();
        }
    }
}
//Save to json file + Load from jsonfile
/*
 * public static void SaveProjectsToFile(string filePath)//save projects to a file Method
{
    var options = new JsonSerializerOptions { WriteIndented = true };
    string jsonString = JsonSerializer.Serialize(projects, options);
    File.WriteAllText(filePath, jsonString);
}
public static void LoadProjectsFromFile(string filePath)//load projects from a file Method
{
    if (File.Exists(filePath))
    {
        string jsonString = File.ReadAllText(filePath);
        projects = JsonSerializer.Deserialize<List<Project>>(jsonString) ?? new List<Project>());
    }
    else
    {
        projects = new List<Project>();
    }
}
*/