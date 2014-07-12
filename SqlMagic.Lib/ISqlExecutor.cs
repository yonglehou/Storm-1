using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlMagic.Lib
{
    public interface ISqlExecutor
    {
        SqlResponse<T> Execute<T>(SqlRequest request);
    }
}
