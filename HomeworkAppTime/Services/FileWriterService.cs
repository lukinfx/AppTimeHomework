using HomeworkAppTime.Services.Interfaces;

namespace HomeworkAppTime.Services
{
    public class FileWriterService : IFileWriterService
    {
        public void WriteFile(string path, string text)
        {
            var targetStream = System.IO.File.Open(path, FileMode.Create, FileAccess.Write);
            var sw = new StreamWriter(targetStream);
            sw.Write(text);
            sw.Close();
            targetStream.Close();
        }
    }
}
