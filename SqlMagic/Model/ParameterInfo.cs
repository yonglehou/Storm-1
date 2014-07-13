using Flyingpie.Storm.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Flyingpie.Storm.Model
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
        public string Name { get; set; }

        public string NameClr
        {
            get { return SqlConverter.ConvertSqlNameToClrName(Name); }
            set { /* Required for serialization */ }
        }

        //[MapTo("ParameterOrdinalPosition")]
        public int Position { get; set; }

        [MapTo("ParameterMode")]
        public string Mode { get; set; }

        [MapTo("ParameterType")]
        public string Type { get; set; }

        public string TypeClr
        {
            get { return SqlConverter.ConvertSqlTypeToClrType(Type, UserDefinedType); }
            set { /* Required for serialization */ }
        }

        [MapTo("UserDefinedTypeName")]
        public string UserDefinedTypeName { get; set; }

        [MapTo("UserDefinedTypeSchema")]
        public string UserDefinedTypeSchema { get; set; }

        public UserDefinedTypeInfo UserDefinedType { get; set; }

        public bool HasUserDefinedType
        {
            get { return UserDefinedType != null; }
            set { /* Required for serialization */ }
        }

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
