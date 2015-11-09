using Flyingpie.Storm.Executors;
using System;

namespace Flyingpie.Storm.Dapper
{
    public class DapperSqlExecutorMiddleWare : IMiddleWare
    {
        private DapperSqlExecutor _executor;

        public DapperSqlExecutorMiddleWare(DapperSqlExecutor executor)
        {
            _executor = executor;
        }

        public Func<SqlRequest, T> Execute<T>(Func<SqlRequest, T> next) where T : SqlResponse
        {
            return request =>
            {
                var response = Activator.CreateInstance<T>();

                response.Execute(request, _executor);

                return response;
            };
        }
    }

    public static class DapperSqlExecutorMiddleWareExtensions
    {
        public static IQueryChain UseDapper(this IQueryChain queryChain, DapperConfiguration configuration)
        {
            var sqlExecutor = new DapperSqlExecutor(configuration);
            queryChain.Use(new DapperSqlExecutorMiddleWare(sqlExecutor));

            return queryChain;
        }
    }
}