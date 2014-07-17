﻿using Flyingpie.Storm.Utility;
using System.Data;
using System.Linq;

namespace Flyingpie.Storm.Model
{
    public class ParameterInfo
    {
        [MapTo("SchemaName")]
        public string SchemaName { get; set; }

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

        public ParameterDirection ParameterModeEnum
        {
            get
            {
                switch (Mode.ToLowerInvariant())
                {
                    case "in":
                        return ParameterDirection.Input;

                    case "inout":
                        return ParameterDirection.InputOutput;

                    case "out":
                        return ParameterDirection.Output;

                    default:
                        return ParameterDirection.Input;
                }
            }
            set { /* Required for serialization */ }
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