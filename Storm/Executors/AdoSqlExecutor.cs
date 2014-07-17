using System;
namespace Flyingpie.Storm.Executors
{
    public class AdoSqlExecutor : ISqlExecutor
    {
        public T Execute<T>(SqlRequest request) where T : SqlResponse
        {
            var response = Activator.CreateInstance<T>();

            response.Execute(request, this);

            return response;
        }

        public System.Data.IDbTransaction BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public int Query(SqlRequest request)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<T> Query<T>(SqlRequest request)
        {
            throw new NotImplementedException();
        }

        public Tuple<System.Collections.Generic.IEnumerable<T1>, System.Collections.Generic.IEnumerable<T2>> Query<T1, T2>(SqlRequest request)
        {
            throw new NotImplementedException();
        }

        public Tuple<System.Collections.Generic.IEnumerable<T1>, System.Collections.Generic.IEnumerable<T2>, System.Collections.Generic.IEnumerable<T3>> Query<T1, T2, T3>(SqlRequest request)
        {
            throw new NotImplementedException();
        }
    }
}