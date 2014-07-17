﻿using Flyingpie.Storm.CodeGenerators;
using Flyingpie.Storm.Formatters;
using Flyingpie.Storm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flyingpie.Storm
{
    public class Generator
    {
        private string _connectionString;

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
            model.RootNamespace = "Database";
            model.Initialize();

            // Generate code
            var codeGenerator = new XsltCodeGenerator(model);
            var code = codeGenerator.Generate(Resources.Xslt.Default);

            var formatter = new DefaultCodeFormatter();
            code = formatter.Format(code);

            return code;
        }
    }
}
