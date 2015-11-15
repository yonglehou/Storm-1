using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using Flyingpie.Storm.Execution;
using Flyingpie.Storm.Execution.Parameters;

namespace Database
{
	#region User Defined Types

	namespace UserDefinedTypes
	{
		namespace Demo
		{
			public partial class UdtModel
			{
				public int? BrandId { get; set; }
				public string Name { get; set; }
				public int? HorsePower { get; set; }
				public int? Year { get; set; }
			}
		}

		namespace IntegrationTest
		{
		}
	}

	#endregion

	#region Interfaces

	public interface IDemo
	{
		ISqlRequest GetAllBrands();
		ISqlRequest GetModelsByBrandIdAndYear(int? brandId, int? year);
		ISqlRequest AddModel(int? brandId, string name, int? horsePower, int? year);
		ISqlRequest GetAllBrandsAndModels();
		ISqlRequest BulkAddModels(IEnumerable<Database.UserDefinedTypes.Demo.UdtModel> models);
	}

	public interface IIntegrationTest
	{
		ISqlRequest QueryNoParameters();
		ISqlRequest NonQueryNoParameters();
		ISqlRequest ScalarNoParameters();
		ISqlRequest MultipleResultSetsNoParameters();
	}

	#endregion

	#region Classes

	public partial class Demo : IDemo
	{
		private IQueryChain _queryChain;
		public Demo(IQueryChain queryChain)
		{
			_queryChain = queryChain;
		}

		public virtual ISqlRequest GetAllBrands()
		{
			var request = new SqlRequest(_queryChain, "Demo", "GetAllBrands");
			return request;
		}

		public virtual ISqlRequest GetModelsByBrandIdAndYear(int? brandId, int? year)
		{
			var request = new SqlRequest(_queryChain, "Demo", "GetModelsByBrandIdAndYear");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BrandId", "int", ParameterDirection.Input, brandId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Year", "int", ParameterDirection.Input, year));
			return request;
		}

		public virtual ISqlRequest AddModel(int? brandId, string name, int? horsePower, int? year)
		{
			var request = new SqlRequest(_queryChain, "Demo", "AddModel");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BrandId", "int", ParameterDirection.Input, brandId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@HorsePower", "int", ParameterDirection.Input, horsePower));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Name", "nvarchar", ParameterDirection.Input, name));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Year", "int", ParameterDirection.Input, year));
			return request;
		}

		public virtual ISqlRequest GetAllBrandsAndModels()
		{
			var request = new SqlRequest(_queryChain, "Demo", "GetAllBrandsAndModels");
			return request;
		}

		public virtual ISqlRequest BulkAddModels(IEnumerable<Database.UserDefinedTypes.Demo.UdtModel> models)
		{
			var request = new SqlRequest(_queryChain, "Demo", "BulkAddModels");
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@Models", "table type", ParameterDirection.Input, "Demo", "udtModel", models));
			return request;
		}
	}

	public partial class IntegrationTest : IIntegrationTest
	{
		private IQueryChain _queryChain;
		public IntegrationTest(IQueryChain queryChain)
		{
			_queryChain = queryChain;
		}

		public virtual ISqlRequest QueryNoParameters()
		{
			var request = new SqlRequest(_queryChain, "IntegrationTest", "Query_NoParameters");
			return request;
		}

		public virtual ISqlRequest NonQueryNoParameters()
		{
			var request = new SqlRequest(_queryChain, "IntegrationTest", "NonQuery_NoParameters");
			return request;
		}

		public virtual ISqlRequest ScalarNoParameters()
		{
			var request = new SqlRequest(_queryChain, "IntegrationTest", "Scalar_NoParameters");
			return request;
		}

		public virtual ISqlRequest MultipleResultSetsNoParameters()
		{
			var request = new SqlRequest(_queryChain, "IntegrationTest", "MultipleResultSets_NoParameters");
			return request;
		}
	}

	#endregion
}
