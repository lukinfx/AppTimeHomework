using HomeworkAppTime.Code;
using HomeworkAppTime.Models;
using HomeworkAppTime.Services.Interfaces;
using System.Text.Json;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace HomeworkAppTime.Services
{
    public class ConvertService : IConvertService
    {
        /// <summary>
        /// Returns Document parsed from string input
        /// </summary>
        /// <param name="input"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Document StringToDocument(string input, Enums.Format format)
        {
            switch (format)
            {
                case Enums.Format.xml:
                    {
                        return XmlToDocument(input);
                    }
                case Enums.Format.json:
                    {
                        return JsonToDocument(input);
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }

        /// <summary>
        /// Returns string of serialized Document
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string DocumentToString(Document doc, Enums.Format format)
        {
            switch (format)
            {
                case Enums.Format.json:
                    {
                        return DocumentToJsonString(doc);
                    }
                case Enums.Format.xml:
                    {
                        return DocumentToXmlString(doc);
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }

        private Document XmlToDocument(string input)
        {
            var xdoc = XDocument.Parse(input);
            var doc = new Document
            {
                Title = xdoc.Root?.Element("title")?.Value,
                Text = xdoc.Root?.Element("text")?.Value
            };
            return doc;
        }
        
        private Document JsonToDocument(string input)
        {
            var deserialized = JsonSerializer.Deserialize<Document>(input);
            var doc = new Document
            {
                Title = deserialized?.Title,
                Text = deserialized?.Text
            };
            return doc;
        }

        private string DocumentToXmlString(Document doc)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(doc.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, doc);
                return textWriter.ToString();
            }
        }

        private string DocumentToJsonString(Document doc)
        {
            var docSerialized = JsonSerializer.Serialize(doc);
            return docSerialized;
        }
    }
}
