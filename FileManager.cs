using System;
using System.Collections.Generic;
using System.IO;

namespace IndividualProjectTodo_List
{
    public static class FileManager
    {
        public static string GetFilePath(string fileName)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
        }

        public static List<Project> LoadProjectsFromFile(string filePath, IFileService fileService, IErrorLogger errorLogger)
        {
            try
            {
                return fileService.LoadFromFile<List<Project>>(filePath) ?? new List<Project>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading projects from file: {ex.Message}");
                errorLogger.LogError(ex);
                return new List<Project>(); // Ensure projects is initialized
            }
        }
    }
}
