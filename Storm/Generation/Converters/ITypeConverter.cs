using Flyingpie.Storm.Generation.Model;

namespace Flyingpie.Storm.Generation.Converters
{
    public interface ITypeConverter
    {
        string ConvertSqlType(ParameterInfo parameter, bool includeReferenceKeyword);

        string ConvertSqlType(UserDefinedTypeColumnInfo column);
    }
}