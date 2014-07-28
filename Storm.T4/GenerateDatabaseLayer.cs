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
			public partial class Vendor
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
		T GetSmallTable<T>(string name, string description) where T : SqlResponse;
		T AddVendors<T>(IEnumerable<Database.UserDefinedTypes.Orm.Vendor> vendors) where T : SqlResponse;
	}

	#endregion

	#region Classes

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
	}

	#endregion
}
