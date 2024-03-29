﻿using System.Xml.Serialization;

namespace Flyingpie.Storm.Generation.Model
{
    public class UserDefinedTypeColumnInfo
    {
        [MapTo("ColumnId")]
        public int Id { get; set; }

        [MapTo("ColumnName")]
        public string Name { get; set; }

        public string NameClr
        {
            get { return GeneratorConfiguration.Instance.NameConverter.ConvertColumnToProperty(Name); }
            set { /* Required for serialization */ }
        }

        [MapTo("ColumnType")]
        public string Type { get; set; }

        public string TypeClr
        {
            get { return GeneratorConfiguration.Instance.TypeConverter.ConvertSqlType(this); }
            set { /* Required for serialization */ }
        }

        [MapTo("SchemaName")]
        public string SchemaName { get; set; }

        [MapTo("UserDefinedTypeName")]
        public string UserDefinedTypeName { get; set; }

        [XmlIgnore]
        public UserDefinedTypeInfo UserDefinedType { get; set; }

        public void Initialize(UserDefinedTypeInfo userDefinedType)
        {
            UserDefinedType = userDefinedType;
        }

        public override string ToString()
        {
            return Name + " " + Type;
        }
    }
}