using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectTodo_List
{

    public class ProjectService : IProjectService
    {
        private readonly List<Project> projects;

        public ProjectService(List<Project> projects)
        {
            this.projects = projects;
        }

        public void CreateProject(string name, string description, string status)
        {
            var project = new Project(name, description, status);
            projects.Add(project);
        }

        public void RemoveProject(Project project)
        {
            projects.Remove(project);
        }

        public void EditProject(Project project, string name, string description, string status)
        {
            project.EditProject(name, description, status);
        }

        public List<Project> GetProjects()
        {
            return projects;
        }
    }

}
