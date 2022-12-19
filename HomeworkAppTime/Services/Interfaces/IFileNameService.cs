using HomeworkAppTime.Code;

namespace HomeworkAppTime.Services.Interfaces
{
    public interface IFileNameService
    {
        string GetSourceFilePath(string fileName);
        string GetTargetFilePath(string fileName);
        string GetFileName(string fileName);
        Enums.Format GetFileFormat(string fileName);
    }
}
