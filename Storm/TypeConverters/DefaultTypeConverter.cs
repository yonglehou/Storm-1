using Flyingpie.Storm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flyingpie.Storm.TypeConverters
{
    public class DefaultTypeConverter : ITypeConverter
    {
        public string ConvertSqlType(ParameterInfo parameter, bool includeReferenceKeyword)
        {
            if (parameter.HasUserDefinedType)
            {
                //TODO: Clean this up, makes code specific
                return "IEnumerable<Database.UserDefinedTypes." + parameter.UserDefinedType.SchemaName + "." + parameter.UserDefinedType.NameClr + ">";
            }
            else
            {
                var typeName = GetBaseType(parameter.Type);

                if (includeReferenceKeyword)
                {
                    switch (parameter.ParameterModeEnum)
                    {
                        case System.Data.ParameterDirection.Input:
                            // Do nothing
                            break;
                        case System.Data.ParameterDirection.InputOutput:
                            typeName = "ref " + typeName;
                            break;
                        case System.Data.ParameterDirection.Output:
                            typeName = "out " + typeName;
                            break;
                        case System.Data.ParameterDirection.ReturnValue:
                            // Do nothing
                            break;
                    }
                }

                return typeName;
            }
        }

        public string ConvertSqlType(UserDefinedTypeColumnInfo column)
        {
            return GetBaseType(column.Type);
        }

        private string GetBaseType(string typeName)
        {
            switch (typeName.ToLowerInvariant())
            {
                case "bit":
                    return "bool?";

                case "date":
                case "datetime":
                case "datetime2":
                case "datetimeoffset":
                case "smalldatetime":
                case "time":
                    return "DateTime?";

                case "int":
                case "tinyint":
                case "smallint":
                    return "int?";

                case "bigint":
                    return "long?";

                case "float":
                case "real":
                    return "float?";

                case "decimal":
                case "money":
                case "numeric":
                case "smallmoney":
                    return "decimal?";

                case "char":
                case "nchar":
                    return "string"; //TODO: Maybe we can read the length of the parameter?

                case "binary":
                case "image":
                case "varbinary":
                    return "byte[]";

                case "text":
                case "nvarchar":
                case "ntext":
                case "varchar":
                    return "string";

                case "timestamp":
                case "rowversion":
                    return "long?";

                case "uniqueidentifier":
                    return "Guid?";

                default:
                    return "object";
            }
        }
    }
}
