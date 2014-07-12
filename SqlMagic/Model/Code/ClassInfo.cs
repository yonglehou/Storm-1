using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlMagic.Model.Code
{
    public class ClassInfo
    {
        public string Name { get; private set; }
        public string Inheritence { get; set; }

        public NamespaceInfo Namespace { get; private set; }
        public ClassInfo Class { get; private set; }

        public List<ClassInfo> Classes { get; private set; }
        public List<MethodInfo> Methods { get; private set; }
        public List<PropertyInfo> Properties { get; private set; }

        public ClassInfo(NamespaceInfo ns, string name)
        {
            Namespace = ns;
            Name = name;

            Classes = new List<ClassInfo>();
            Methods = new List<MethodInfo>();
            Properties = new List<PropertyInfo>();
        }

        public ClassInfo(ClassInfo c, string name)
        {
            Class = c;
            Name = name;

            Classes = new List<ClassInfo>();
            Methods = new List<MethodInfo>();
            Properties = new List<PropertyInfo>();
        }

        public override string ToString()
        {
            if(Namespace != null)
            {
                if(!string.IsNullOrEmpty(Namespace.Name))
                {
                    return Namespace.Name + "." + Name;
                }
            }
            if (Class != null)
            {
                if (!string.IsNullOrEmpty(Class.Name))
                {
                    return Class.Name + "." + Name;
                }
            }
            return Name;
        }

        public static readonly ClassInfo Bool = new ClassInfo(NamespaceInfo.None, "bool");
        public static readonly ClassInfo ByteArray = new ClassInfo(NamespaceInfo.None, "byte[]");
        public static readonly ClassInfo Char = new ClassInfo(NamespaceInfo.None, "char");
        public static readonly ClassInfo DateTime = new ClassInfo(NamespaceInfo.System, "DateTime");
        public static readonly ClassInfo Decimal = new ClassInfo(NamespaceInfo.None, "decimal");
        public static readonly ClassInfo Guid = new ClassInfo(NamespaceInfo.System, "Guid");
        public static readonly ClassInfo Int = new ClassInfo(NamespaceInfo.None, "int");
        public static readonly ClassInfo Object = new ClassInfo(NamespaceInfo.None, "object");
        public static readonly ClassInfo String = new ClassInfo(NamespaceInfo.None, "string");
        public static readonly ClassInfo Void = new ClassInfo(NamespaceInfo.None, "void");
    }
}
