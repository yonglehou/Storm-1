using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Flyingpie.Storm;
using Database;
using Flyingpie.Storm.Dapper;
using Flyingpie.Storm.MiddleWare;

namespace UserTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var queryChain = new QueryChain();

            queryChain.UseConsoleLogger();
            queryChain.UseExceptionHandler();
            queryChain.UseDapper(new DapperConfiguration()
            {
                ConnectionString = "server=DBCS_PRD_SQLSRV;database=Naleving;integrated security=true;"
            });

            var dbo = new Dbo(queryChain);
        }
    }
}
