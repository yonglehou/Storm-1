using Flyingpie.Storm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flyingpie.Storm.Converters
{
    public interface ITypeConverter
    {
        string ConvertSqlType(ParameterInfo parameter, bool includeReferenceKeyword);
        string ConvertSqlType(UserDefinedTypeColumnInfo column);
    }
}
