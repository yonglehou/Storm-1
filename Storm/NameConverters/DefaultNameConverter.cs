using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flyingpie.Storm.NameConverters
{
    public class DefaultNameConverter : INameConverter
    {
        public virtual string ConvertSchemaToInterface(string name)
        {
            name = name.Replace("@", "");

            return "I" + Capitalize(name);
        }

        public virtual string ConvertSchemaToClass(string name)
        {
            name = name.Replace("@", "");

            return Capitalize(name);
        }

        public virtual string ConvertStoredProcedureToMethod(string name)
        {
            name = name.Replace("@", "");

            return Capitalize(name);
        }

        public virtual string ConvertParameter(string name)
        {
            name = name.Replace("@", "");

            return name;
        }

        public virtual string ConvertColumnToProperty(string name)
        {
            name = name.Replace("@", "");

            return Capitalize(name);
        }

        public string ConvertUserDefinedTypeToClass(string name)
        {
            name = name.Replace("@", "");

            return Capitalize(name);
        }

        private string Capitalize(string value)
        {
            return value[0].ToString().ToUpper() + (value.Length > 1 ? value.Substring(1) : string.Empty);
        }
    }
}
