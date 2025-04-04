using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using IndividualProjectTodo_List;

public class FileService
{
    public void SaveProjectsToFile(List<Project> projects, string filePath)
    {
        var json = JsonSerializer.Serialize(projects);
        File.WriteAllText(filePath, json);
    }

    public List<Project> LoadProjectsFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<Project>();
        }

        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<Project>>(json);
    }
}
