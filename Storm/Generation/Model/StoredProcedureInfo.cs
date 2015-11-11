using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Serialization;

namespace Flyingpie.Storm.Generation.Model
{
    public class StoredProcedureInfo
    {
        [MapTo("StoredProcedureName")]
        public string Name { get; set; }

        public string NameClr
        {
            get { return GeneratorConfiguration.Instance.NameConverter.ConvertStoredProcedureToMethod(Name); }
            set { /* Required for serialization */ }
        }

        [MapTo("SchemaName")]
        public string SchemaName { get; set; }

        [XmlIgnore]
        public SchemaInfo Schema { get; set; }

        public List<ParameterInfo> Parameters { get; set; }

        public string ParameterString
        {
            get
            {
                return string.Join(", ", Parameters
                    .OrderBy(p => p.Position)
                    .Select(p => p.TypeRefClr + " " + p.NameClr).
                    ToArray());
            }
            set { /* Required for serialization */ }
        }

        internal void Initialize(SchemaInfo schema)
        {
            Schema = schema;
            Parameters = schema.Database.Parameters.Where(p => p.SchemaName == SchemaName && p.StoredProcedureName == Name).ToList();
            Parameters.ForEach(p => p.Initialize(this));
        }

        public override string ToString()
        {
            return SchemaName + "." + Name;
        }
    }
}