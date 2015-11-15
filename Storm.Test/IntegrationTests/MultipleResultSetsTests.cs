using Database;
using Flyingpie.Storm.Execution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Storm.Test.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flyingpie.Storm.Test.IntegrationTests
{
    [TestClass]
    public class MultipleResultSetsTests
    {
        private IQueryChain _queryChain;

        private IIntegrationTest _it;

        [TestInitialize]
        public void Initialize()
        {
            _queryChain = new QueryChain()
                .UseDapper(new Dapper.DapperConfiguration()
                {
                    ConnectionStringName = "TestDatabase"
                });

            _it = new IntegrationTest(_queryChain);
        }

        [TestMethod]
        public void IntegrationTest_Multiple_NoParameters()
        {
            using (var result = _it.MultipleResultSetsNoParameters().Multiple())
            {
                var r1 = result.Read<Brand>();
                Assert.IsNotNull(r1);
                Assert.AreEqual(5, r1.Count());

                // TODO: Check contents

                var r2 = result.Read<Model>();
                Assert.IsNotNull(r2);
                Assert.AreEqual(2, r2.Count());

                // TODO: Check contents
            }
        }
    }
}
