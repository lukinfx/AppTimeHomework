using HomeworkAppTime.Services.Interfaces;

namespace HomeworkAppTime.Services
{
    public class FileLoaderService : IFileLoaderService
    {
        public string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
