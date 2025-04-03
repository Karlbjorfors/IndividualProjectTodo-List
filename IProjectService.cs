﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectTodo_List
{
    public interface IProjectService
    {
        void CreateProject(string name, string description, string status);
        void RemoveProject(Project project);
        void EditProject(Project project, string name, string description, string status);
        List<Project> GetProjects();
    }

}
