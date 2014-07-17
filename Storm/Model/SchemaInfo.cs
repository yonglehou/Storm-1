using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Flyingpie.Storm.Model
{
    public class SchemaInfo
    {
        [MapTo("SchemaId")]
        public int Id { get; set; }

        [MapTo("SchemaName")]
        public string Name { get; set; }

        public List<StoredProcedureInfo> StoredProcedures { get; set; }

        public List<UserDefinedTypeInfo> UserDefinedTypes { get; set; }

        [XmlIgnore]
        public DatabaseModel Database { get; set; }

        internal void Initialize(DatabaseModel database)
        {
            Database = database;

            StoredProcedures = database.StoredProcedures.Where(sp => sp.SchemaName == Name).ToList();
            StoredProcedures.ForEach(sp => sp.Initialize(this));

            UserDefinedTypes = database.UserDefinedTypes.Where(sp => sp.SchemaName == Name).ToList();
            UserDefinedTypes.ForEach(udt => udt.Initialize(this));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}