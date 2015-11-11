using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Flyingpie.Storm.Converters
{
    //public class DefaultValueConverter : IValueConverter
    //{
    //    public object Convert(object value, string sqlTypeName)
    //    {
    //        // Prevent casting errors with nulls
    //        if(value == null)
    //        {
    //            return null;
    //        }

    //        var t = value.GetType();
    //        sqlTypeName = sqlTypeName.ToUpperInvariant();

    //        if (t == typeof(DateTime))
    //        {
    //            // Convert to ISO 8601 format, in order to maintain precision
    //            var dt = (DateTime)value;
    //            switch(sqlTypeName)
    //            {
    //                case "DATETIME":
    //                    return dt.ToString("yyyy-MM-ddTHH:mm:ss.fff", CultureInfo.InvariantCulture);
    //                case "DATETIME2":
    //                    return dt.ToString("yyyy-MM-ddTHH:mm:ss.fffffff", CultureInfo.InvariantCulture);
    //                default:
    //                    return dt;
    //            }
    //        }
    //        else
    //        {
    //            return value;
    //        }
    //    }
    //}
}
