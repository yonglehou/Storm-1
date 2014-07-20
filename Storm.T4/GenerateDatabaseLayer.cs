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
		}
	}

	#endregion

	#region Interfaces

	public interface IOrm
	{
		T GetSmallTable<T>(string Description, string Name) where T : SqlResponse;
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
	}

	#endregion
}
