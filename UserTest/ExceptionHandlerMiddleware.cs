using Flyingpie.Storm.Execution;
using System;
using System.Diagnostics;

namespace UserTest
{
    public class ExceptionHandlerMiddleWare : IMiddleware
    {
        public Func<ISqlRequest, ISqlExecutor> Execute(Func<ISqlRequest, ISqlExecutor> next)
        {
            return request =>
            {
                Debug.WriteLine("2 Exception handler middle ware START.");

                var result = next(request);

                Debug.WriteLine("2 Exception handler middle ware STOP.");

                return result;
            };
        }
    }

    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IQueryChain UseExceptionHandler(this IQueryChain queryChain)
        {
            queryChain.Use(new ExceptionHandlerMiddleWare());

            return queryChain;
        }
    }
}