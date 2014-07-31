using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Flyingpie.Storm.Utility
{
    public static class IEnumerableExtensions
    {
        public static DataTable ToDataTable(this IEnumerable items, string udtName)
        {
            var tb = new DataTable(udtName);
            
            PropertyInfo[] props = null;
            
            // We need the element's properties to add them as columns to the data table, which is somewhat tricky because of the non-generic IEnumerable
            var genericArguments = items.GetType().GetGenericArguments();
            if(!genericArguments.Any())
            {
                throw new ArgumentException("Could not determine element type of '" + items.GetType() + "'");
            }

            props = genericArguments.First().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {
                var t = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType; // Get underlying type, should it be a nullable
                tb.Columns.Add(prop.Name, t);
            }
            
            foreach (var item in items)
            {
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