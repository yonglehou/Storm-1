using Flyingpie.Storm.Utility;
using System.Collections.Generic;
using System.Linq;

namespace Flyingpie.Storm.Model
{
    public class UserDefinedTypeInfo
    {
        [MapTo("UserDefinedTypeName")]
        public string Name { get; set; }

        public string NameClr
        {
            get { return SqlConverter.ConvertSqlNameToClrName(Name); }
            set { /* Required for serialization */ }
        }

        [MapTo("SchemaName")]
        public string SchemaName { get; set; }

        public List<UserDefinedTypeColumnInfo> Columns { get; set; }

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