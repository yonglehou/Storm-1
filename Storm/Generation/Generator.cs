using Flyingpie.Storm.Generation.CodeGenerators;
using Flyingpie.Storm.Generation.Formatters;
using Flyingpie.Storm.Generation.Model;
using System;

namespace Flyingpie.Storm.Generation
{
    public class Generator
    {
        private string _connectionString;

        private ICodeGenerator _generator;

        private Generator()
        {
        }

        public static Generator FromConnectionString(string connectionString)
        {
            var generator = new Generator();
            generator._connectionString = connectionString;
            return generator;
        }

        public static Generator FromConnectionStringName(string connectionStringName)
        {
            throw new NotImplementedException();
        }

        public string Generate()
        {
            // Generate database model
            var model = new DatabaseModel(_connectionString);
            model.Initialize();

            // Generate code
            var codeGenerator = new XsltCodeGenerator(Resources.Xslt.Default);
            var code = codeGenerator.Generate(model);

            var formatter = new DefaultCodeFormatter();
            code = formatter.Format(code);

            return code;
        }
    }
}