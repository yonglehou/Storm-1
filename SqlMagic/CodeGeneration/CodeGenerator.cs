using SqlMagic.Model.Code;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SqlMagic.CodeGeneration
{
    public class CodeGenerator
    {
        public CodeModel Model { get; private set; }

        public CodeGenerator(CodeModel model)
        {
            Model = model;
        }

        public void Generate(Stream stream)
        {
            using (var writer = new StreamWriter(stream))
            {
                foreach(var ns in Model.Namespaces)
                {
                    var nsGen = new NamespaceGenerator(writer, ns);
                    nsGen.Write();
                }
            }
        }
    }
}
