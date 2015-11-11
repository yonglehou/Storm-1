using Flyingpie.Storm.Execution;
using System;

namespace Flyingpie.Storm.Dapper
{
    public class DapperSqlExecutorMiddleware : IMiddleware
    {
        private DapperConfiguration _configuration;
        private ISqlExecutor _executor;

        public DapperSqlExecutorMiddleware(DapperConfiguration configuration)
        {
            _configuration = configuration;
            _executor = new DapperSqlExecutor(_configuration);
        }

        public Func<ISqlRequest, ISqlExecutor> Execute(Func<ISqlRequest, ISqlExecutor> next)
        {
            return request =>
            {
                return _executor;
            };
        }
    }
}