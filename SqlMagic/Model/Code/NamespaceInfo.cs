using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlMagic.Model.Code
{
    public class NamespaceInfo
    {
        public string Name { get; private set; }

        public List<ClassInfo> Classes { get; private set; }

        public NamespaceInfo(string name)
        {
            Name = name;
            Classes = new List<ClassInfo>();
        }

        public override string ToString()
        {
            return Name;
        }

        public static readonly NamespaceInfo None = new NamespaceInfo(string.Empty);
        public static readonly NamespaceInfo System = new NamespaceInfo("System");
    }
}
