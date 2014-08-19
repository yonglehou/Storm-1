using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flyingpie.Storm.Converters
{
    public class DefaultValueConverter : IValueConverter
    {
        public object Convert(object value)
        {
            // Prevent casting errors with nulls
            if(value == null)
            {
                return null;
            }

            var t = value.GetType();

            if (t == typeof(DateTime))
            {
                // Convert to ISO 8601 format, in order to maintain precision
                var dt = (DateTime)value;
                return dt.ToString("o", System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                return value;
            }
        }
    }
}
