using SqlMagic.Model.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlMagic.Utility
{
    public static class SqlConverter
    {
        public static ClassInfo ConvertSqlTypeToClrType(CodeModel codeModel, Model.Database.ParameterInfo parameterInfo)
        {
            if (parameterInfo.UserDefinedType != null)
            {
                var a = codeModel.Namespaces
                    .SelectMany(n => n.Classes)
                    .SelectMany(c => c.Classes)
                    .Single(c => c.Name == parameterInfo.UserDefinedTypeName);

                return a;
            }
            else
            {
                return ConvertSqlTypeToClrType(codeModel, parameterInfo.Type.ToString());
            }
        }

        public static ClassInfo ConvertSqlTypeToClrType(CodeModel codeModel, string typeName)
        {
            switch (typeName.ToLowerInvariant())
            {
                case "bit":
                    return ClassInfo.Bool;

                case "date":
                case "datetime":
                case "datetime2":
                case "time":
                    return ClassInfo.DateTime;

                case "int":
                case "tinyint":
                case "smallint":
                    return ClassInfo.Int;

                case "money":
                    return ClassInfo.Decimal;

                case "char":
                case "nchar":
                    return ClassInfo.Char;

                case "varbinary":
                    return ClassInfo.ByteArray;

                case "nvarchar":
                case "varchar":
                    return ClassInfo.String;

                case "uniqueidentifier":
                    return ClassInfo.Guid;

                default:
                    return ClassInfo.Object;
            }
        }
    }
}
