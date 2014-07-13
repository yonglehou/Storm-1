using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flyingpie.Storm.Lib
{
    public interface ISqlExecutor
    {
        SqlResponse Execute(SqlRequest request);
    }
}
