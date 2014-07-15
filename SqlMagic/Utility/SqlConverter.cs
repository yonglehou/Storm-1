using Flyingpie.Storm.Model;

namespace Flyingpie.Storm.Utility
{
    public static class SqlConverter
    {
        public static string ConvertSqlNameToClrName(string name)
        {
            name = name.Replace("@", "");

            return name;
        }

        public static string ConvertSqlTypeToClrType(string typeName, UserDefinedTypeInfo udt)
        {
            if (udt != null)
            {
                //TODO: Clean this up, makes code specific
                return "IEnumerable<Database.UserDefinedTypes." + udt.SchemaName + "." + udt.NameClr + ">";
            }
            else
            {
                switch (typeName.ToLowerInvariant())
                {
                    case "bit":
                        return "bool?";

                    case "date":
                    case "datetime":
                    case "datetime2":
                    case "time":
                        return "DateTime";

                    case "int":
                    case "tinyint":
                    case "smallint":
                        return "int?";

                    case "money":
                        return "decimal?";

                    case "char":
                    case "nchar":
                        return "char?";

                    case "varbinary":
                        return "byte[]";

                    case "nvarchar":
                    case "varchar":
                        return "string";

                    case "uniqueidentifier":
                        return "Guid";

                    default:
                        return "object";
                }
            }
        }
    }
}