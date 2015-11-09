using Flyingpie.Storm.Executors;
using System;
using System.Collections.Generic;

namespace Flyingpie.Storm
{
    public class QueryChain : IQueryChain
    {
        public List<IMiddleWare> MiddleWare { get; private set; }

        public QueryChain()
        {
            MiddleWare = new List<IMiddleWare>();
        }

        public void Use(IMiddleWare middleWare)
        {
            MiddleWare.Add(middleWare);
        }

        public T Execute<T>(SqlRequest request) where T : SqlResponse
        {
            Func<SqlRequest, T> mw = null;

            for (int i = MiddleWare.Count - 1; i >= 0; i--)
            {
                mw = MiddleWare[i].Execute(mw);
            }

            return mw(request);
        }
    }
}