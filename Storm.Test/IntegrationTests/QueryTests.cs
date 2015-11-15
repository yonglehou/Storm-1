using Database;
using Flyingpie.Storm.Execution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Storm.Test.Dto;
using System.Linq;

namespace Flyingpie.Storm.Test.IntegrationTests
{
    [TestClass]
    public class QueryTests
    {
        private IQueryChain _queryChain;
        private IIntegrationTest _it;

        [TestInitialize]
        public void Initialize()
        {
            _queryChain = new QueryChain()
                .UseDapper(new Dapper.DapperConfiguration()
                {
                    ConnectionString = "server=.;database=Storm;integrated security=true;"
                });

            _it = new IntegrationTest(_queryChain);
        }

        [TestMethod]
        public void IntegrationTest_Query_NoParameters()
        {
            var result = _it.QueryNoParameters().Query<Brand>();

            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count());

            var audi = result.FirstOrDefault(r => r.Id == 1);
            Assert.IsNotNull(audi);
            Assert.AreEqual("Audi", audi.Name);
            Assert.AreEqual("Never follow", audi.Description);
            Assert.AreEqual(150, audi.HorsePower);

            var bmw = result.FirstOrDefault(r => r.Id == 2);
            Assert.IsNotNull(bmw);
            Assert.AreEqual("BMW", bmw.Name);
            Assert.AreEqual("The ultimate driving machine", bmw.Description);
        }

        [TestMethod]
        public void IntegrationTest_Query_SingleParameter_NotNull()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void IntegrationTest_Query_SingleParameter_Null()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void IntegrationTest_Query_MultipleParameters_NotNull()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void IntegrationTest_Query_MultipleParameters_Null()
        {
            Assert.Inconclusive();
        }
    }
}