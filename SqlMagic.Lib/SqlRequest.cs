using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SqlMagic.Lib
{
    public class SqlRequest
    {
        public string StoredProcedureName { get; set; }
        public List<StoredProcedureParameter> Parameters { get; set; }

        public SqlRequest()
        {
            Parameters = new List<StoredProcedureParameter>();
        }
    }

    public abstract class StoredProcedureParameter
    {
        public string Name { get; set; }
    }

    public class StoredProcedureSimpleParameter : StoredProcedureParameter
    {
        public object Value { get; set; }
    }

    public class StoredProcedureTableTypeParameter : StoredProcedureParameter
    {
        public IList Table { get; set; }
    }
}
