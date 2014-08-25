using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flyingpie.Storm.Converters
{
    public class DefaultNameConverter : INameConverter
    {
        public virtual string ConvertSchemaToInterface(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                return name;
            }

            name = name.Replace("@", "");

            return "I" + Capitalize(name);
        }

        public virtual string ConvertSchemaToClass(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                return name;
            }

            name = name.Replace("@", "");

            return Capitalize(name);
        }

        public virtual string ConvertSchemaToNamespace(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                return name;
            }

            name = name.Replace("@", "");

            return Capitalize(name);
        }

        public virtual string ConvertStoredProcedureToMethod(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                return name;
            }

            name = name.Replace("@", "");

            return Capitalize(name);
        }

        public virtual string ConvertParameter(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                return name;
            }

            name = name.Replace("@", "");

            name = Capitalize(name);

            name = name.Substring(0, 1).ToLower() + (name.Length > 1 ? name.Substring(1) : string.Empty);

            return name;
        }

        public virtual string ConvertColumnToProperty(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                return name;
            }

            name = name.Replace("@", "");

            return Capitalize(name);
        }

        public string ConvertUserDefinedTypeToClass(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                return name;
            }

            name = name.Replace("@", "");

            return Capitalize(name);
        }

        private string Capitalize(string value)
        {
            if(string.IsNullOrEmpty(value))
            {
                return value;
            }

            var sb = new StringBuilder();

            var capitalizeNext = false;
            var lastWasUpper = false;
            for (int i = 0; i < value.Length; i++)
            {
                var c = value[i];

                var isUpper = char.IsUpper(c);

                // If the last character was upper-case and this one is upper-case as well, make this one lower case
                // AA -> Aa
                if (lastWasUpper && isUpper)
                {
                    c = char.ToLower(c);
                }

                // If this character is an underscore, keep that in the back of our heads and move on
                if (c == '_')
                {
                    capitalizeNext = true;
                    continue;
                }

                // Capitalize if neccessary
                // aa -> aA
                if (capitalizeNext)
                {
                    sb.Append(c.ToString().ToUpper());
                    capitalizeNext = false;
                }
                else
                {
                    sb.Append(c);
                }

                lastWasUpper = isUpper;
            }

            value = sb.ToString();

            // Make the first character a capital and append the rest of the string, if it is longer than 1 character
            return value[0].ToString().ToUpper() + (value.Length > 1 ? value.Substring(1) : string.Empty);
        }
    }
}
