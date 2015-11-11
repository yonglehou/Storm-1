using Flyingpie.Storm.Generation.Model;

namespace Flyingpie.Storm.Generation.Converters
{
    public class DefaultTypeConverter : ITypeConverter
    {
        public string ConvertSqlType(ParameterInfo parameter, bool includeReferenceKeyword)
        {
            if (parameter.HasUserDefinedType)
            {
                //TODO: Clean this up, makes code specific
                return string.Format(
                    "IEnumerable<{0}.UserDefinedTypes." + parameter.UserDefinedType.Schema.NamespaceName + "." + parameter.UserDefinedType.NameClr + ">",
                    GeneratorConfiguration.Instance.RootNamespace);
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
                            //typeName = "ref " + typeName;
                            typeName = "OutputParameter<" + typeName + ">";
                            break;

                        case System.Data.ParameterDirection.Output:
                            //typeName = "out " + typeName;
                            typeName = "OutputParameter<" + typeName + ">";
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