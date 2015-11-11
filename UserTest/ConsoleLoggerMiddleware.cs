using Flyingpie.Storm.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace UserTest
{
    public class ConsoleLoggerMiddleware : IMiddleware
    {
        public Func<ISqlRequest, ISqlExecutor> Execute(Func<ISqlRequest, ISqlExecutor> next)
        {
            return request =>
            {
                Debug.WriteLine("1 Console log middle ware START.");

                var result = new ConsoleLoggerInterceptor(next(request));

                Debug.WriteLine("1 Console log middle ware STOP.");

                return result;
            };
        }
    }

    public static class ConsoleLoggerMiddlewareExtensions
    {
        public static IQueryChain UseConsoleLogger(this IQueryChain queryChain)
        {
            queryChain.Use(new ConsoleLoggerMiddleware());

            return queryChain;
        }
    }

    public class ConsoleLoggerInterceptor : ISqlExecutor
    {
        private ISqlExecutor _executor;

        public ConsoleLoggerInterceptor(ISqlExecutor executor)
        {
            _executor = executor;
        }

        public IDbTransaction BeginTransaction()
        {
            Debug.WriteLine("Begin transaction START.");

            var result = _executor.BeginTransaction();

            Debug.WriteLine("Begin transaction STOP.");

            return result;
        }

        public void Dispose()
        {
            _executor.Dispose();
        }

        public IMultipleResultSetReader Multiple(ISqlRequest request)
        {
            Debug.WriteLine("Multiple START.");

            var result = new ConsoleLoggerMultipleResultSetReader(_executor.Multiple(request));

            Debug.WriteLine("Multiple STOP.");

            return result;
        }

        public void NonQuery(ISqlRequest request)
        {
            Debug.WriteLine("NonQuery START.");

            _executor.NonQuery(request);

            Debug.WriteLine("NonQuery STOP.");
        }

        public IEnumerable<T> Query<T>(ISqlRequest request)
        {
            Debug.WriteLine("Query START (" + typeof(T).ToString() + ").");

            var result = _executor.Query<T>(request);

            Debug.WriteLine("ITEMS:");

            foreach (var a in result)
            {
                Debug.WriteLine("ITEM: " + a.ToString());
            }

            Debug.WriteLine("/ITEMS");

            Debug.WriteLine("Query STOP.");

            return result;
        }

        public T Scalar<T>(ISqlRequest request)
        {
            Debug.WriteLine("Scalar START (" + typeof(T).ToString() + ").");

            var result = _executor.Scalar<T>(request);

            Debug.WriteLine("Scalar STOP (" + result + ").");

            return result;
        }
    }

    public class ConsoleLoggerMultipleResultSetReader : IMultipleResultSetReader
    {
        private IMultipleResultSetReader _reader;

        public ConsoleLoggerMultipleResultSetReader(IMultipleResultSetReader reader)
        {
            _reader = reader;
        }

        public void Dispose()
        {
            _reader.Dispose();
        }

        public IEnumerable<T> Read<T>()
        {
            Debug.WriteLine("Read<T> START (" + typeof(T).ToString() + ").");

            var result = _reader.Read<T>();

            Debug.WriteLine("ITEMS:");

            foreach (var a in result)
            {
                Debug.WriteLine("ITEM: " + a.ToString());
            }

            Debug.WriteLine("/ITEMS");

            Debug.WriteLine("Read<T> STOP (" + result.Count() + " rows).");

            return result;
        }
    }
}