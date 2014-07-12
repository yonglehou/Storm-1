using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlMagic.Lib
{
    public class SqlResponse
    {

    }

    public class SqlResponse<T>
    {
        public IEnumerable<T> Items { get; set; }
    }
}
