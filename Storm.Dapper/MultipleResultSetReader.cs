using Flyingpie.Storm.Execution;
using System.Collections.Generic;

namespace Flyingpie.Storm.Dapper
{
    public class MultipleResultSetReader : IMultipleResultSetReader
    {
        private global::Dapper.SqlMapper.GridReader _reader;

        public MultipleResultSetReader(global::Dapper.SqlMapper.GridReader reader)
        {
            _reader = reader;
        }

        public IEnumerable<T> Read<T>()
        {
            return _reader.Read<T>();
        }

        public void Dispose()
        {
            _reader.Dispose();
        }
    }
}