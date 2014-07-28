using Flyingpie.Storm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flyingpie.Storm.TypeConverters
{
    public interface ITypeConverter
    {
        string ConvertSqlType(ParameterInfo parameter);
        string ConvertSqlType(UserDefinedTypeColumnInfo column);
    }
}
