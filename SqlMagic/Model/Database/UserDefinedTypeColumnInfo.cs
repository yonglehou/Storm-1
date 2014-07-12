using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlMagic.Model.Database
{
    public class UserDefinedTypeColumnInfo
    {
        [MapTo("ColumnId")]
        public int Id { get; private set; }

        [MapTo("ColumnName")]
        public string Name { get; private set; }

        [MapTo("ColumnType")]
        public string Type { get; private set; }

        [MapTo("SchemaName")]
        public string SchemaName { get; private set; }

        [MapTo("UserDefinedTypeName")]
        public string UserDefinedTypeName { get; private set; }

        public override string ToString()
        {
            return Name + " " + Type;
        }
    }
}
