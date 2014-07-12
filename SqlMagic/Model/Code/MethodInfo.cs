using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlMagic.Model.Code
{
    public class MethodInfo
    {
        public string Name { get; private set; }

        public ClassInfo Class { get; private set; }
        public List<ParameterInfo> Parameters { get; private set; }
        public ClassInfo ReturnType { get; private set; }
        public string MethodBody { get; set; }
        public string ReturnCode { get; set; }

        public MethodInfo(ClassInfo classInfo, string name, ClassInfo returnType)
        {
            Class = classInfo;
            Name = name;
            Parameters = new List<ParameterInfo>();
            ReturnType = returnType;
        }

        public MethodInfo(ClassInfo classInfo, string name) : this(classInfo, name, ClassInfo.Void)
        {
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Name + "(");
            foreach (var p in Parameters)
            {
                if (sb.Length > 0) sb.Append(", ");

                sb.Append(sb.ToString());
            }
            sb.Append(")");

            return sb.ToString();
        }
    }
}
