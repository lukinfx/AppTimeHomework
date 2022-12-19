using HomeworkAppTime.Code;
using HomeworkAppTime.Controllers;
using HomeworkAppTime.Models;
using HomeworkAppTime.Services.Interfaces;
using NSubstitute;

namespace TestProject
{

    [TestClass]
    public class ControllerTest
    {
        [TestMethod]
        public void ControllerBaseTest()
        {
            IFileLoaderService fileLoaderService = Substitute.For<IFileLoaderService>();
            fileLoaderService.ReadFile(Arg.Any<string>())
                .Returns(@"<note><title>Title</title><text>text text text</text></note>");

            IFileWriterService fileWriterService= Substitute.For<IFileWriterService>();
            IFileNameService fileNameService= Substitute.For<IFileNameService>();

            IConvertService convertService = Substitute.For<IConvertService>();
            convertService.StringToDocument(Arg.Any<string>(), Arg.Any<Enums.Format>()).Returns(new Document { Text = "text text text", Title = "Title" });
            convertService.DocumentToString(Arg.Any<Document>(), Enums.Format.json).Returns("{\"Title\":\"Title\",\"Text\":\"text text text\"}");

            var controller = new ConvertController(fileLoaderService, fileWriterService, fileNameService, convertService);
            controller.ConvertFile(Enums.Format.json, "Document1.xml");

            fileWriterService.Received().WriteFile(Arg.Any<string>(), "{\"Title\":\"Title\",\"Text\":\"text text text\"}");
        }
    }
}
