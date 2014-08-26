using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Flyingpie.Storm;
using Flyingpie.Storm.Executors;

namespace Database
{
	#region User Defined Types

	namespace UserDefinedTypes
	{
		namespace Cars
		{
			[GeneratedCode("Flyingpie.Storm", "1.0.0.0")]
			public partial class Brand
			{
				public string Name { get; set; }
				public string Description { get; set; }
				public int? HorsePower { get; set; }
				public byte[] Image { get; set; }
			}
		}

		namespace Utility
		{
		}
	}

	#endregion

	#region Interfaces

	[GeneratedCode("Flyingpie.Storm", "1.0.0.0")]
	public interface ICars
	{
		T GetBrands<T>(string name, string description) where T : SqlResponse;
		T AddBrand<T>(IEnumerable<Database.UserDefinedTypes.Cars.Brand> vendors) where T : SqlResponse;
		T GetBrandsAndModels<T>() where T : SqlResponse;
	}

	[GeneratedCode("Flyingpie.Storm", "1.0.0.0")]
	public interface IUtility
	{
		T GetAddition<T>(int? valueA, int? valueB) where T : SqlResponse;
		T EchoDateTime<T>(DateTime? dateTime) where T : SqlResponse;
	}

	#endregion

	#region Classes

	[GeneratedCode("Flyingpie.Storm", "1.0.0.0")]
	public partial class Cars : ICars
	{
		private ISqlExecutor _executor;
		public Cars(ISqlExecutor executor)
		{
			_executor = executor;
		}

		public virtual T GetBrands<T>(string name, string description) where T : SqlResponse
		{
			var request = new SqlRequest("Cars", "GetBrands");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Description", "nvarchar", ParameterDirection.Input, description));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Name", "nvarchar", ParameterDirection.Input, name));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public virtual T AddBrand<T>(IEnumerable<Database.UserDefinedTypes.Cars.Brand> vendors) where T : SqlResponse
		{
			var request = new SqlRequest("Cars", "AddBrand");
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@Vendors", "table type", ParameterDirection.Input, "Cars", "Brand", vendors));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public virtual T GetBrandsAndModels<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Cars", "GetBrandsAndModels");
			var result = _executor.Execute<T>(request);
			return result;
		}
	}

	[GeneratedCode("Flyingpie.Storm", "1.0.0.0")]
	public partial class Utility : IUtility
	{
		private ISqlExecutor _executor;
		public Utility(ISqlExecutor executor)
		{
			_executor = executor;
		}

		public virtual T GetAddition<T>(int? valueA, int? valueB) where T : SqlResponse
		{
			var request = new SqlRequest("Utility", "GetAddition");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ValueA", "int", ParameterDirection.Input, valueA));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ValueB", "int", ParameterDirection.Input, valueB));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public virtual T EchoDateTime<T>(DateTime? dateTime) where T : SqlResponse
		{
			var request = new SqlRequest("Utility", "EchoDateTime");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DateTime", "datetime2", ParameterDirection.Input, dateTime));
			var result = _executor.Execute<T>(request);
			return result;
		}
	}

	#endregion
}
