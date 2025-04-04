using System.Collections.Generic;

namespace IndividualProjectTodo_List
{
    public static class ApplicationInitializer
    {
        public static List<Project> InitializeProjects()
        {
            return new List<Project>();
        }

        public static void InitializeServices(List<Project> projects, out IProjectService projectService, out ITaskService taskService, out IFileService fileService, out IErrorLogger errorLogger)
        {
            projectService = new ProjectService(projects);
            taskService = new TaskService(projects);
            fileService = new FileService();
            errorLogger = new ErrorLogger();
        }
    }
}
