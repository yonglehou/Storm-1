using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flyingpie.Storm.Converters
{
    public interface IValueConverter
    {
        object Convert(object value, string sqlTypeName);
    }
}
