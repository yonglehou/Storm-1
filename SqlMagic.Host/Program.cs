using SqlMagic.CodeGeneration;
using SqlMagic.Model.Code;
using SqlMagic.Model.Database;
using SqlMagic.Output;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SqlMagic.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            new Example();

            // Generate database model
            var model = new DatabaseModel("Data Source=DBCS_DEV_SQLSRV;Initial catalog=DBCServices5;Integrated Security=true;");
            model.Initialize();

            // Generate code model
            var code = new CodeModel(model);
            code.Initialize();

            // Generate code
            var fileName = @"C:\Users\Marco vd Oever\Documents\Visual Studio 2012\Projects\SqlMagic\SqlMagic.Output\Database.Generated.cs";
            File.Delete(fileName);
            var stream = File.OpenWrite(fileName);
            var codeGenerator = new CodeGenerator(code);
            codeGenerator.Generate(stream);
        }
    }
}
