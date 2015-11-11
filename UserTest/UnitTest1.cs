using Flyingpie.Storm.Execution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UserTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /// Setup
            var queryChain = new QueryChain();
            var schema = new Schema(queryChain);
            var request = schema.CspExampleStoredProcedure(1);

            /// Usage
            // Non-query
            request.NonQuery();

            // Scalar
            var scalar = request.Scalar<int>();

            // Query
            var result = request.Query<SampleDto1>();
            var item1 = result.First();

            // Multiple
            using (var reader = request.Multiple())
            {
                var result1 = reader.Read<SampleDto1>();
                var item2 = result1.First();

                var result2 = reader.Read<SampleDto2>();
                var item3 = result2.First();
            }

            // Output parameter
            var id = new OutputParameter<int>(1);

            schema.CspWithOutputParameter(id).Query<SampleDto1>();

            
        }

        public void Archive()
        {
            //queryChain.UseConsoleLogger();
            //queryChain.UseExceptionHandler();
            //queryChain.UseDapper(new DapperConfiguration()
            //{
            //    ConnectionString = "server=DBCS_PRD_SQLSRV;database=Naleving;integrated security=true;"
            //});

            //var dbo = new Dbo(queryChain);
        }
    }

    public class OutputParameter<T>
    {
        public T Value { get; set; }

        public OutputParameter(T value)
        {
            Value = value;
        }
    }

    public interface ISchema
    {
        ISqlRequest CspExampleStoredProcedure(int id);

        ISqlRequest CspWithOutputParameter(OutputParameter<int> id);
    }

    public class Schema : ISchema
    {
        private IQueryChain _queryChain;

        public Schema(IQueryChain queryChain)
        {
            _queryChain = queryChain;
        }

        public ISqlRequest CspExampleStoredProcedure(int id)
        {
            return new SqlRequest(_queryChain, "", "");
        }

        public ISqlRequest CspWithOutputParameter(OutputParameter<int> id)
        {
            return null;
        }
    }

    public class SampleDto1
    {
        public string SampleDto1Name { get; set; }
    }

    public class SampleDto2
    {
        public string SampleDto2Name { get; set; }
    }
}