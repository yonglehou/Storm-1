using Flyingpie.Storm.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Flyingpie.Storm.Model
{
    public class UserDefinedTypeInfo
    {
        [MapTo("UserDefinedTypeName")]
        public string Name { get; set; }

        public string NameClr
        {
            get { return GeneratorConfiguration.Instance.NameConverter.ConvertUserDefinedTypeToClass(Name); }
            set { /* Required for serialization */ }
        }

        [MapTo("SchemaName")]
        public string SchemaName { get; set; }

        public List<UserDefinedTypeColumnInfo> Columns { get; set; }

        [XmlIgnore]
        public SchemaInfo Schema { get; set; }

        internal void Initialize(SchemaInfo schema)
        {
            Schema = schema;

            Columns = schema.Database.UserDefinedTypeColumns.Where(udtc => udtc.SchemaName == SchemaName && udtc.UserDefinedTypeName == Name).ToList();
            Columns.ForEach(c => c.Initialize(this));
        }

        public override string ToString()
        {
            return SchemaName + "." + Name;
        }
    }
}