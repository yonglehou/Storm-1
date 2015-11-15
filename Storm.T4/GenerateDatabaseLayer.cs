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
		namespace Dbo
		{
		}
	}

	#endregion

	#region Interfaces

	[GeneratedCode("Flyingpie.Storm", "1.0.0.0")]
	public interface IDbo
	{
		ISqlRequest IntegrationTestQueryNoParameters();
	}

	#endregion

	#region Classes

	[GeneratedCode("Flyingpie.Storm", "1.0.0.0")]
	public partial class Dbo : IDbo
	{
		private IQueryChain _queryChain;
		public Dbo(IQueryChain queryChain)
		{
			_queryChain = queryChain;
		}

		public virtual ISqlRequest IntegrationTestQueryNoParameters()
		{
			var request = new SqlRequest(_queryChain, "dbo", "IntegrationTest_Query_NoParameters");
			return request;
		}
	}

	#endregion
}
