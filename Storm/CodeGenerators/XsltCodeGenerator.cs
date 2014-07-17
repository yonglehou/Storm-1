using Flyingpie.Storm.Model;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Flyingpie.Storm.CodeGenerators
{
    public class XsltCodeGenerator
    {
        public DatabaseModel Model { get; private set; }

        public XsltCodeGenerator(DatabaseModel model)
        {
            Model = model;
        }

        public string Generate(string xslt)
        {
            var result = new StringBuilder();

            using (var stream = new MemoryStream())
            using (var writer = XmlWriter.Create(result, new XmlWriterSettings() { ConformanceLevel = ConformanceLevel.Fragment }))
            {
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(Model.GetType());
                x.Serialize(stream, Model);
                stream.Position = 0;

                var doc = new XPathDocument(stream);
                var transform = new XslCompiledTransform();
                var xmlReader = XmlReader.Create(new StringReader(xslt));
                transform.Load(xmlReader);
                transform.Transform(doc, writer);
            }

            return result.ToString();
        }
    }
}