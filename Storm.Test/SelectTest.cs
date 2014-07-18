using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Flyingpie.Storm.Executors;
using Flyingpie.Storm.Dapper;
using Database;
using Storm.Test.Dto;
using System.Collections.Generic;
using System.Diagnostics;

namespace Storm.Test
{
    [TestClass]
    public class SelectTest
    {
        #region Storm

        [TestMethod]
        public void Select()
        {
            var executor = DapperSqlExecutor.FromConnectionStringName("TestDatabase");
            var orm = new Orm(executor);

            var result = orm.GetSmallTable<SqlResponse<SmallTableRow>>(null, null);

            Assert.AreEqual(10, result.Items.Count());

            Assert.IsTrue(result.Items.Any(i => i.Name == "Audi" && i.Description == "The steering wheel is an option"));
            Assert.IsTrue(result.Items.Any(i => i.Name == "Volvo" && i.Description == "The search for perfection ends here"));
        }

        #endregion
    }
}
