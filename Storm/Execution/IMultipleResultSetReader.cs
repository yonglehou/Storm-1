using System;
using System.Collections.Generic;

namespace Flyingpie.Storm.Execution
{
    public interface IMultipleResultSetReader : IDisposable
    {
        IEnumerable<T> Read<T>();
    }
}