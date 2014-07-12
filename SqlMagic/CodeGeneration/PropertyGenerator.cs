using SqlMagic.Model.Code;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SqlMagic.CodeGeneration
{
    public class PropertyGenerator
    {
        public StreamWriter Writer { get; private set; }
        public PropertyInfo Property { get; private set; }

        public PropertyGenerator(StreamWriter sw, PropertyInfo propertyInfo)
        {
            Writer = sw;
            Property = propertyInfo;
        }

        public void Write()
        {
            Writer.WriteLine("public {0} {1} {{ get; set; }}", Property.Type.ToString(), Property.Name);
        }
    }
}
