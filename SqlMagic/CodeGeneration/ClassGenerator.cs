using SqlMagic.Model.Code;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SqlMagic.CodeGeneration
{
    public class ClassGenerator
    {
        public StreamWriter Writer { get; private set; }
        public ClassInfo ClassInfo { get; private set; }

        public ClassGenerator(StreamWriter writer, ClassInfo classInfo)
        {
            Writer = writer;
            ClassInfo = classInfo;
        }

        public void Write()
        {
            Begin();

            ClassInfo.Properties.ForEach(property =>
            {
                var propGen = new PropertyGenerator(Writer, property);
                propGen.Write();
            });

            ClassInfo.Classes.ForEach(subClass =>
            {
                var classGen = new ClassGenerator(Writer, subClass);
                classGen.Write();
            });

            ClassInfo.Methods.ForEach(method =>
            {
                var methodGen = new MethodGenerator(Writer, method);
                methodGen.Write();
            });

            End();
        }

        private void Begin()
        {
            var inheritence = !string.IsNullOrEmpty(ClassInfo.Inheritence) ? " : " + ClassInfo.Inheritence : string.Empty;
            Writer.WriteLine("public class {0}{1}", ClassInfo.Name, inheritence);
            Writer.WriteLine("{");
        }

        private void End()
        {
            Writer.WriteLine("}");
        }
    }
}
