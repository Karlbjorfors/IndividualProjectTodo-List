using System;

namespace IndividualProjectTodo_List
{
    public static class TaskUpdater
    {
        public static void UpdateTaskDetailsFromUserInput(TodoTask task)
        {
            Console.WriteLine("Enter new task description:");
            string taskDescription = Console.ReadLine();
            Console.WriteLine("Enter new due date (yyyy-MM-dd):");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter new task status:");
            string taskStatus = Console.ReadLine();

            task.EditTask(task.Name, taskDescription, dueDate, taskStatus);
        }
    }
}
