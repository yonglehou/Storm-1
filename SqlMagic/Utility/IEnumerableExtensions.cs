using System;
using System.Collections;
using System.Data;
using System.Reflection;

namespace Flyingpie.Storm.Utility
{
    public static class IEnumerableExtensions
    {
        public static DataTable ToDataTable(this IEnumerable items, string udtName)
        {
            var tb = new DataTable(udtName);
            
            PropertyInfo[] props = null;

            foreach (var item in items)
            {
                if (props == null)
                {
                    props = item.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

                    foreach (var prop in props)
                    {
                        tb.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType));
                    }
                }

                var values = new object[props.Length];
                for (var i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                tb.Rows.Add(values);
            }

            return tb;
        }
    }
}