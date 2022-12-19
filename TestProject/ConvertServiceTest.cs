using HomeworkAppTime.Services;
using System.Xml;
using HomeworkAppTime.Code;

namespace TestProject
{
    [TestClass]
    public class ConvertServiceTest
    {
        [TestMethod]
        public void TestToDocument_Xml_Ok()
        {
            ConvertService convertService = new ConvertService();
            var input = @"<note>
                            <title>Title</title>
                            <text>text text text</text>
                        </note>";
            var document = convertService.StringToDocument(input, Enums.Format.xml);
            Assert.IsNotNull(document);
            Assert.AreEqual("Title", document.Title);
            Assert.AreEqual("text text text", document.Text);
        }

        [TestMethod]
        [ExpectedException(typeof(XmlException))]
        public void TestToDocument_Xml_WrongFormat()
        {
            ConvertService convertService = new ConvertService();
            var input = @"ahoj";
            convertService.StringToDocument(input, Enums.Format.xml);
        }

        [TestMethod]
        public void TestToDocument_Xml_WrongFormat2()
        {
            ConvertService convertService = new ConvertService();
            var input = @"ahoj";
            Assert.ThrowsException<XmlException>(() => convertService.StringToDocument(input, Enums.Format.xml));
        }

    }
}