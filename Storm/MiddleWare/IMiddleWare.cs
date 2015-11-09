using Flyingpie.Storm.Executors;
using System;
using System.Diagnostics;

namespace Flyingpie.Storm.MiddleWare
{
    public class ConsoleLoggerMiddleWare : IMiddleWare
    {
        public Func<SqlRequest, T> Execute<T>(Func<SqlRequest, T> next) where T : SqlResponse
        {
            return request =>
            {
                Debug.WriteLine("1 Console log middle ware START.");

                var result = next(request);

                Debug.WriteLine("1 Console log middle ware STOP.");

                return result;
            };
        }
    }

    public class ExceptionHandlerMiddleWare : IMiddleWare
    {
        public Func<SqlRequest, T> Execute<T>(Func<SqlRequest, T> next) where T : SqlResponse
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

    public static class MiddleWareExtensions
    {
        public static IQueryChain UseConsoleLogger(this IQueryChain queryChain)
        {
            queryChain.Use(new ConsoleLoggerMiddleWare());

            return queryChain;
        }

        public static IQueryChain UseExceptionHandler(this IQueryChain queryChain)
        {
            queryChain.Use(new ExceptionHandlerMiddleWare());

            return queryChain;
        }
    }
}