using Flyingpie.Storm.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Flyingpie.Storm
{
    public static class SqlUtil
    {
        public static List<T> Query<T>(this SqlConnection connection, string query)
        {
            using (var command = new SqlCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                return reader.DataReaderMapToList<T>();
            }
        }

        public static List<T> DataReaderMapToList<T>(this IDataReader dr)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    var mapTo = prop.GetCustomAttributes(typeof(MapToAttribute), false).FirstOrDefault() as MapToAttribute;

                    if (mapTo != null)
                    {
                        if (!object.Equals(dr[mapTo.Column], DBNull.Value))
                        {
                            prop.SetValue(obj, dr[mapTo.Column], null);
                        }
                    }
                }
                list.Add(obj);
            }

            return list;
        }
    }
}
