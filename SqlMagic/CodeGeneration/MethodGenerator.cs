using SqlMagic.Model.Code;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SqlMagic.CodeGeneration
{
    public class MethodGenerator
    {
        public StreamWriter Writer { get; private set; }
        public MethodInfo Method { get; private set; }

        public MethodGenerator(StreamWriter sw, MethodInfo methodInfo)
        {
            Writer = sw;
            Method = methodInfo;
        }

        public void Write()
        {
            Begin();

            End();
        }

        private void Begin()
        {
            var sb = new StringBuilder();
            foreach (var parameter in Method.Parameters)
            {
                if (sb.Length > 0) sb.Append(", ");
                sb.Append(parameter.ToString());
            }
            var returnType = Method.ReturnType != null ? " " + Method.ReturnType : string.Empty;

            Writer.WriteLine("public{0} {1}({2})", returnType, Method.Name, sb.ToString());
            Writer.WriteLine("{");
            Writer.WriteLine(Method.MethodBody);
            if (Method.ReturnType != null)
            {
                Writer.WriteLine("return {0}", Method.ReturnCode);
            }
        }

        private void End()
        {
            Writer.WriteLine("}");
        }
    }
}
