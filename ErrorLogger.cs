using System;
using System.IO;

namespace IndividualProjectTodo_List
{
    public class ErrorLogger : IErrorLogger
    {
        public void LogError(Exception ex)
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
}
