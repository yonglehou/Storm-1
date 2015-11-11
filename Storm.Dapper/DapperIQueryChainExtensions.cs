using Flyingpie.Storm.Dapper;

namespace Flyingpie.Storm.Execution
{
    public static class DapperIQueryChainExtensions
    {
        public static IQueryChain UseDapper(this IQueryChain queryChain, DapperConfiguration configuration)
        {
            return queryChain.Use(new DapperSqlExecutorMiddleware(configuration));
        }
    }
}