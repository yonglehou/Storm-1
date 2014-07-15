using Flyingpie.Storm.Model;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Flyingpie.Storm.CodeGeneration
{
    public class XsltCodeGenerator
    {
        public DatabaseModel Model { get; private set; }

        public XsltCodeGenerator(DatabaseModel model)
        {
            Model = model;
        }

        public string Generate(string xsltFile)
        {
            var result = new StringBuilder();

            using (var stream = new MemoryStream())
            using (var writer = XmlWriter.Create(result, new XmlWriterSettings() { ConformanceLevel = ConformanceLevel.Fragment }))
            {
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(Model.GetType());
                x.Serialize(stream, Model);
                stream.Position = 0;

                File.WriteAllBytes(@"C:\Temp\Test.xml", stream.ToArray());

                var doc = new XPathDocument(stream);
                var transform = new XslCompiledTransform();
                transform.Load(xsltFile);
                transform.Transform(doc, writer);
            }

            return result.ToString();
        }
    }
}