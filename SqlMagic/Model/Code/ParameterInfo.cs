using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlMagic.Model.Code
{
    public class ParameterInfo
    {
        public string Name { get; private set; }

        public MethodInfo Method { get; private set; }
        public ClassInfo Type { get; private set; }
        public bool IsRef { get; private set; }

        public ParameterInfo(MethodInfo methodInfo, string name, ClassInfo type, bool isRef)
        {
            Method = methodInfo;
            Name = name;
            Type = type;
            IsRef = isRef;
        }

        public override string ToString()
        {
            var prefix = IsRef ? "ref " : "";
            return prefix + Type.ToString() + " " + Name;
        }
    }
}
