using Database;
using Flyingpie.Storm.Execution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flyingpie.Storm.Test.IntegrationTests
{
    [TestClass]
    public class ScalarTests
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
        public void IntegrationTest_Scalar_NoParameters()
        {
            var result = _it.ScalarNoParameters().Scalar<int>();

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void IntegrationTest_Scalar_SingleParameter_NotNull()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void IntegrationTest_Scalar_SingleParameter_Null()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void IntegrationTest_Scalar_MultipleParameters_NotNull()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void IntegrationTest_Scalar_MultipleParameters_Null()
        {
            Assert.Inconclusive();
        }
    }
}