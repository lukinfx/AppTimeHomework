using HomeworkAppTime.Code;
using HomeworkAppTime.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkAppTime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvertController : ControllerBase
    {
        private IFileLoaderService _fileLoaderService;
        private IFileWriterService _fileWriterService;
        private IFileNameService _fileNameService;
        private IConvertService _convertService;
        public ConvertController(IFileLoaderService fileLoaderService, IFileWriterService fileWriterService, IFileNameService fileNameService, IConvertService convertService)
        {
            _fileLoaderService = fileLoaderService;
            _fileWriterService = fileWriterService;
            _fileNameService = fileNameService;
            _convertService = convertService;
        }

        [HttpPost]
        public async Task<string> UploadFile(IFormFile file)
        {
            string path = "";
            try
            {
                if (file.Length > 0)
                {
                    path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..\\Source Files"));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    var sourceFormat = _fileNameService.GetFileFormat(file.FileName);

                    var fileGuid = Guid.NewGuid();
                    var fileName = fileGuid.ToString() + "." + sourceFormat;

                    using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    return fileName;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("File Copy Failed", ex);
            }
        }

        [HttpPut]
        public string ConvertFile(Enums.Format targetFormat, string sourceFileName)
        {
            var sourceFormat = _fileNameService.GetFileFormat(sourceFileName);
            var sourceName = _fileNameService.GetFileName(sourceFileName);

            var tragetFileName = sourceName + "." + targetFormat;

            var sourceFilePath = _fileNameService.GetSourceFilePath(sourceFileName);
            var targetFilePath = _fileNameService.GetTargetFilePath(tragetFileName);

            string input = _fileLoaderService.ReadFile(sourceFilePath);

            var doc = _convertService.StringToDocument(input, sourceFormat);
            var serializedDoc = _convertService.DocumentToString(doc, targetFormat);

            _fileWriterService.WriteFile(targetFilePath, serializedDoc);
            return tragetFileName;
        }

        [HttpGet]
        public async Task<ActionResult> DownloadFile(string fileName)
        {
            var sourceFileName = _fileNameService.GetTargetFilePath(fileName);
            var bytes = await System.IO.File.ReadAllBytesAsync(sourceFileName);
            return File(bytes, "text/plain", Path.GetFileName(sourceFileName));
        }
    }
}
