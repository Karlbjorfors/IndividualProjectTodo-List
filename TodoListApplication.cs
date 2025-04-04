using System;
using System.Collections.Generic;

namespace IndividualProjectTodo_List
{
    public class TodoListApplication
    {
        public static void Main(string[] args)
        {
            List<Project> projects = ApplicationInitializer.InitializeProjects();
            ApplicationInitializer.InitializeServices(projects, out IProjectService projectService, out ITaskService taskService, out IFileService fileService, out IErrorLogger errorLogger);

            string filePath = FileManager.GetFilePath("tasks.json");
            projects = FileManager.LoadProjectsFromFile(filePath, fileService, errorLogger);

            MainMenu mainMenu = new MainMenu(taskService, fileService, errorLogger, filePath);
            mainMenu.Run();
        }
    }
}
