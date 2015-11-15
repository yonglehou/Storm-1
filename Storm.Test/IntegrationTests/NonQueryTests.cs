using Database;
using Flyingpie.Storm.Execution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flyingpie.Storm.Test.IntegrationTests
{
    [TestClass]
    public class NonQueryTests
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
        public void IntegrationTest_NonQuery_NoParameters()
        {
            _it.NonQueryNoParameters().NonQuery();
        }

        [TestMethod]
        public void IntegrationTest_NonQuery_SingleParameter_NotNull()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void IntegrationTest_NonQuery_SingleParameter_Null()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void IntegrationTest_NonQuery_MultipleParameters_NotNull()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void IntegrationTest_NonQuery_MultipleParameters_Null()
        {
            Assert.Inconclusive();
        }
    }
}