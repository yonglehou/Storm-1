using Flyingpie.Storm.Model;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Flyingpie.Storm.CodeGenerators
{
    public class XsltCodeGenerator : ICodeGenerator
    {
        private string _xslt;

        public XsltCodeGenerator(string xslt)
        {
            _xslt = xslt;
        }

        public string Generate(DatabaseModel model)
        {
            var result = new StringBuilder();

            using (var stream = new MemoryStream())
            using (var writer = XmlWriter.Create(result, new XmlWriterSettings() { ConformanceLevel = ConformanceLevel.Fragment }))
            {
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(model.GetType());
                x.Serialize(stream, model);
                stream.Position = 0;

                var doc = new XPathDocument(stream);
                var transform = new XslCompiledTransform();
                var xmlReader = XmlReader.Create(new StringReader(_xslt));
                transform.Load(xmlReader);
                transform.Transform(doc, writer);
            }

            return result.ToString();
        }
    }
}