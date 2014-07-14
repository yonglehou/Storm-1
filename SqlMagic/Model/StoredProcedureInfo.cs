using Flyingpie.Storm.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Flyingpie.Storm.Model
{
    public class StoredProcedureInfo
    {
        [MapTo("StoredProcedureName")]
        public string Name { get; set; }

        [MapTo("SchemaName")]
        public string SchemaName { get; set; }

        [XmlIgnore]
        public SchemaInfo Schema { get; set; }
        public List<ParameterInfo> Parameters { get; set; }

        public string ParameterString
        {
            get { return string.Join(", ", Parameters.Select(p => 
                (p.ParameterModeEnum == ParameterInfo.ParameterMode.In ? "" : "ref ") +
                p.TypeClr + " " + p.NameClr).ToArray()); }
            set { /* Required for serialization */ }
        }

        internal void Initialize(SchemaInfo schema)
        {
            Schema = schema;
            Parameters = schema.Database.Parameters.Where(p => p.StoredProcedureName == Name).ToList();
            Parameters.ForEach(p => p.Initialize(this));
        }

        public override string ToString()
        {
            return SchemaName + "." + Name;
        }
    }
}
