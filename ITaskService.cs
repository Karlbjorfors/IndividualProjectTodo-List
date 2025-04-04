using System.Collections.Generic;

namespace IndividualProjectTodo_List
{
    public interface ITaskService
    {
        void AddTask();
        void EditTask();
        void MarkTaskAsDone();
        void RemoveTask();
        void ListTasks();
        List<Project> GetProjects();
    }
}
