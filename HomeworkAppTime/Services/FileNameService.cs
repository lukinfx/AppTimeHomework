using HomeworkAppTime.Code;
using HomeworkAppTime.Services.Interfaces;

namespace HomeworkAppTime.Services
{
    public class FileNameService : IFileNameService
    {
        public Enums.Format GetFileFormat(string fileName)
        {
            ValidateFileName(fileName);
            var tempFileNameParsed = fileName.Split(".");
            var tempFileName = tempFileNameParsed[tempFileNameParsed.Length - 1];
            
            switch (tempFileName)
            {
                case "json":
                    {
                        return Enums.Format.json;
                    }
                case "xml":
                    {
                        return Enums.Format.xml;
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }

        public string GetFileName(string fileName)
        {
            ValidateFileName(fileName);
            var tempFileNameParsed = fileName.Split(".");
            return tempFileNameParsed[tempFileNameParsed.Length - 2];
        }

        public string GetSourceFilePath(string fileName)
        {
            ValidateFileName(fileName);
            return Path.Combine(Environment.CurrentDirectory, "..\\Source Files\\", fileName);
        }

        public string GetTargetFilePath(string fileName)
        {
            ValidateFileName(fileName);
            return Path.Combine(Environment.CurrentDirectory, "..\\Target Files\\", fileName);
        }

        private bool ValidateFileName(string filename)
        {
            if (filename.Split(".").Count() != 2)
            {
                throw new ArgumentException("filename format is not correct");
            }
            return true;
        }
    }
}
