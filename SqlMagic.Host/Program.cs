using Flyingpie.Storm.CodeGeneration;
using Flyingpie.Storm.Model;
using System;
using System.IO;

namespace Flyingpie.Storm.Host
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Generate or execute? (g/E)");
            var action = Console.ReadLine();

            if (action.ToUpper() == "G")
            {
                Generate();
            }
            else
            {
                new Example();
            }
        }

        private static void Generate()
        {
            var root = @"C:\Users\marcovdo\Source\Repos\Storm\SqlMagic.Host";
            var transform = @"Default.xslt";
            var output = @"Database.Generated.cs";

            // Generate database model
            Console.WriteLine("Generating model from database..");
            var model = new DatabaseModel("Data Source=DBCS_PRD_SQLSRV;Initial catalog=DBCServices5;Integrated Security=true;");
            model.Initialize();

            // Generate code
            Console.WriteLine("Generating code from model..");
            var fileName = Path.Combine(root, output);
            
            var codeGenerator = new XsltCodeGenerator(model);
            var code = codeGenerator.Generate(Path.Combine(root, transform));

            var formatter = new DefaultCodeFormatter();
            code = formatter.Format(code);

            File.WriteAllText(Path.Combine(root, output), code);
        }
    }
}