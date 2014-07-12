using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlMagic.Model.Database
{
    public class UserDefinedTypeInfo
    {
        [MapTo("UserDefinedTypeName")]
        public string Name { get; private set; }

        [MapTo("SchemaName")]
        public string SchemaName { get; private set; }

        public List<UserDefinedTypeColumnInfo> Columns { get; private set; }

        internal void Initialize(SchemaInfo schema)
        {
            Columns = schema.Database.UserDefinedTypeColumns.Where(udtc => udtc.SchemaName == SchemaName && udtc.UserDefinedTypeName == Name).ToList();
        }

        public override string ToString()
        {
            return SchemaName + "." + Name;
        }
    }
}
