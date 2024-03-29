﻿using System.Data;
namespace Flyingpie.Storm.Execution
{
    public interface IQueryChain
    {
        IQueryChain Use(IMiddleware middleware);

        ISqlExecutor CreateExecutor(ISqlRequest request);

        IDbTransaction BeginTransaction();
    }
}