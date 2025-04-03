using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectTodo_List
{
    public interface ITaskService
    {
        void AddTask();
        void EditTask();
        void MarkTaskAsDone();
        void RemoveTask();
        void ListTasks();
    }

}
