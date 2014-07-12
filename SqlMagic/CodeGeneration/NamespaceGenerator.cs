using SqlMagic.Model.Code;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SqlMagic.CodeGeneration
{
    public class NamespaceGenerator
    {
        public StreamWriter Writer { get; private set; }
        public NamespaceInfo Namespace { get; private set; }

        public NamespaceGenerator(StreamWriter writer, NamespaceInfo ns)
        {
            Writer = writer;
            Namespace = ns;
        }

        public void Write()
        {
            Begin();

            Namespace.Classes.ForEach(c =>
            {
                var classGen = new ClassGenerator(Writer, c);
                classGen.Write();
            });

            End();
        }

        public void Begin()
        {
            Writer.WriteLine("using System;");
            Writer.WriteLine("");
            Writer.WriteLine("namespace {0}", Namespace);
            Writer.WriteLine("{");
        }

        public void End()
        {
            Writer.WriteLine("}");
        }
    }
}
