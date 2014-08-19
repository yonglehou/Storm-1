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
		namespace Orm
		{
			[GeneratedCode("Flyingpie.Storm", "1.0.0.0")]
			public partial class Vendor
			{
				public string Name { get; set; }
				public string Description { get; set; }
				public int? HorsePower { get; set; }
				public byte[] Image { get; set; }
			}
		}
	}

	#endregion

	#region Interfaces

	[GeneratedCode("Flyingpie.Storm", "1.0.0.0")]
	public interface IOrm
	{
		T GetSmallTable<T>(string name, string description) where T : SqlResponse;
		T AddVendors<T>(IEnumerable<Database.UserDefinedTypes.Orm.Vendor> vendors) where T : SqlResponse;
		T GetScalar<T>(int? valueA, int? valueB) where T : SqlResponse;
		T EchoDateTime<T>(DateTime? dateTime) where T : SqlResponse;
	}

	#endregion

	#region Classes

	[GeneratedCode("Flyingpie.Storm", "1.0.0.0")]
	public partial class Orm : IOrm
	{
		private ISqlExecutor _executor;
		public Orm(ISqlExecutor executor)
		{
			_executor = executor;
		}

		public virtual T GetSmallTable<T>(string name, string description) where T : SqlResponse
		{
			var request = new SqlRequest("Orm", "GetSmallTable");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Description", ParameterDirection.Input, description));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Name", ParameterDirection.Input, name));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public virtual T AddVendors<T>(IEnumerable<Database.UserDefinedTypes.Orm.Vendor> vendors) where T : SqlResponse
		{
			var request = new SqlRequest("Orm", "AddVendors");
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@Vendors", ParameterDirection.Input, "Orm", "Vendor", vendors));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public virtual T GetScalar<T>(int? valueA, int? valueB) where T : SqlResponse
		{
			var request = new SqlRequest("Orm", "GetScalar");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ValueA", ParameterDirection.Input, valueA));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ValueB", ParameterDirection.Input, valueB));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public virtual T EchoDateTime<T>(DateTime? dateTime) where T : SqlResponse
		{
			var request = new SqlRequest("Orm", "EchoDateTime");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DateTime", ParameterDirection.Input, dateTime));
			var result = _executor.Execute<T>(request);
			return result;
		}
	}

	#endregion
}
