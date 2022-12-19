
using HomeworkAppTime.Code;
using HomeworkAppTime.Models;

namespace HomeworkAppTime.Services.Interfaces
{
    public interface IConvertService
    {
        public Document StringToDocument(string plainText, Enums.Format format);
        string DocumentToString(Document doc, Enums.Format format);
    }
}
