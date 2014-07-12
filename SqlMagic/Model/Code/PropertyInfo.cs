using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlMagic.Model.Code
{
    public class PropertyInfo
    {
        public ClassInfo Class { get; private set; }
        public ClassInfo Type { get; private set; }
        public string Name { get; private set; }

        public PropertyInfo(ClassInfo classInfo, ClassInfo type, string name)
        {
            Class = classInfo;
            Type = type;
            Name = name;
        }
    }
}
