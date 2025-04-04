using System.Collections.Generic;

namespace IndividualProjectTodo_List
{
    public class ProjectService : IProjectService
    {
        private readonly List<Project> _projects;

        public ProjectService(List<Project> projects)
        {
            _projects = projects;
        }

        public void CreateProject(string name, string description, string status)
        {
            var project = new Project(name, description, status);
            _projects.Add(project);
        }

        public void RemoveProject(Project project)
        {
            _projects.Remove(project);
        }

        public void EditProject(Project project, string name, string description, string status)
        {
            project.EditProject(name, description, status);
        }

        public List<Project> GetProjects()
        {
            return _projects;
        }
    }
}
