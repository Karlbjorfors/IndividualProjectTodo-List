namespace IndividualProjectTodo_List
{
    public interface IFileService
    {
        void SaveToFile<T>(string filePath, T data);
        T LoadFromFile<T>(string filePath);
    }
}
