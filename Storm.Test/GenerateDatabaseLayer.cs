using System;
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
			public class Vendor
			{
				public string Name { get; set; }
				public string Description { get; set; }
			}
		}
	}

	#endregion

	#region Interfaces

	public interface IOrm
	{
		T GetSmallTable<T>(string Description, string Name) where T : SqlResponse;
		T AddVendors<T>(IEnumerable<Database.UserDefinedTypes.Orm.Vendor> Vendors) where T : SqlResponse;
		T GetScalar<T>(int? ValueA, int? ValueB) where T : SqlResponse;
	}

	#endregion

	#region Classes

	public class Orm : IOrm
	{
		private ISqlExecutor _executor;
		public Orm(ISqlExecutor executor)
		{
			_executor = executor;
		}

		public T GetSmallTable<T>(string Description, string Name) where T : SqlResponse
		{
			var request = new SqlRequest("Orm", "GetSmallTable");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Description", ParameterDirection.Input, Description));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Name", ParameterDirection.Input, Name));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T AddVendors<T>(IEnumerable<Database.UserDefinedTypes.Orm.Vendor> Vendors) where T : SqlResponse
		{
			var request = new SqlRequest("Orm", "AddVendors");
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@Vendors", ParameterDirection.Input, "Orm", "Vendor", Vendors));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T GetScalar<T>(int? ValueA, int? ValueB) where T : SqlResponse
		{
			var request = new SqlRequest("Orm", "GetScalar");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ValueA", ParameterDirection.Input, ValueA));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ValueB", ParameterDirection.Input, ValueB));
			var result = _executor.Execute<T>(request);
			return result;
		}
	}

	#endregion
}
