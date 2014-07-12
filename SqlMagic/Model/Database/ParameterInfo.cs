using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SqlMagic.Model.Database
{
    public class ParameterInfo
    {
        public enum ParameterMode
        {
            In,
            Out,
            InOut
        }

        [MapTo("StoredProcedureName")]
        public string StoredProcedureName { get; set; }

        [MapTo("ParameterName")]
        public string Name { get; private set; }

        [MapTo("ParameterOrdinalPosition")]
        public int Position { get; private set; }

        [MapTo("ParameterMode")]
        public string Mode { get; private set; }

        [MapTo("ParameterType")]
        public string Type { get; private set; }

        [MapTo("UserDefinedTypeName")]
        public string UserDefinedTypeName { get; private set; }

        [MapTo("UserDefinedTypeSchema")]
        public string UserDefinedTypeSchema { get; private set; }

        public UserDefinedTypeInfo UserDefinedType { get; private set; }

        public ParameterMode ParameterModeEnum
        {
            get
            {
                switch (Mode.ToLowerInvariant())
                {
                    case "in":
                        return ParameterMode.In;
                    case "inout":
                        return ParameterMode.InOut;
                    case "out":
                        return ParameterMode.Out;
                    default:
                        return ParameterMode.In;
                }
            }
        }

        internal void Initialize(StoredProcedureInfo storedProcedure)
        {
            UserDefinedType = storedProcedure.Schema.Database.UserDefinedTypes.FirstOrDefault(udt => udt.SchemaName == UserDefinedTypeSchema && udt.Name == UserDefinedTypeName);
        }

        public override string ToString()
        {
            return Name + " " + Type;
        }
    }
}
