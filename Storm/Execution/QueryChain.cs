using System;
using System.Collections.Generic;
using System.Data;

namespace Flyingpie.Storm.Execution
{
    public class QueryChain : IQueryChain
    {
        public List<IMiddleware> Middleware { get; private set; }

        public QueryChain()
        {
            Middleware = new List<IMiddleware>();
        }

        public IQueryChain Use(IMiddleware middleware)
        {
            Middleware.Add(middleware);

            return this;
        }

        public ISqlExecutor CreateExecutor(ISqlRequest request)
        {
            Func<ISqlRequest, ISqlExecutor> mw = null;

            for (int i = Middleware.Count - 1; i >= 0; i--)
            {
                mw = Middleware[i].Execute(mw);
            }

            if (mw == null)
                throw new InvalidOperationException("Cannot create executor, have you added an executor to the pipeline?");

            return mw(request);
        }

        public IDbTransaction BeginTransaction()
        {
            return CreateExecutor(null).BeginTransaction();
        }
    }
}