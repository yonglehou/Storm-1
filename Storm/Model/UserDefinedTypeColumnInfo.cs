using Flyingpie.Storm.Utility;

namespace Flyingpie.Storm.Model
{
    public class UserDefinedTypeColumnInfo
    {
        [MapTo("ColumnId")]
        public int Id { get; set; }

        [MapTo("ColumnName")]
        public string Name { get; set; }

        public string NameClr
        {
            get { return SqlConverter.ConvertSqlNameToClrName(Name); }
            set { /* Required for serialization */ }
        }

        [MapTo("ColumnType")]
        public string Type { get; set; }

        public string TypeClr
        {
            get { return SqlConverter.ConvertSqlTypeToClrType(Type, null); }
            set { /* Required for serialization */ }
        }

        [MapTo("SchemaName")]
        public string SchemaName { get; set; }

        [MapTo("UserDefinedTypeName")]
        public string UserDefinedTypeName { get; set; }

        public override string ToString()
        {
            return Name + " " + Type;
        }
    }
}