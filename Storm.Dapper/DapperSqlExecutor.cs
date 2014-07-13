using Flyingpie.Storm.Lib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using global::Dapper;

namespace Storm.Dapper
{
    public class DapperSqlExecutor : ISqlExecutor
    {
        public SqlResponse Execute(SqlRequest request)
        {
            var response = new SqlResponse();
            /*
            using (IDbConnection connection = new SqlConnection("server=DBCS_PRD_SQLSRV;database=DBCServices5;integrated security=true;"))
            {
                Dictionary<string, object> parameters = new Dictionary<string,object>();
                foreach (var p in request.Parameters)
                {
                    parameters[p.Name] = "a";
                }

                var result = connection.Query(
                    string.Format("{0}.{1}", request.SchemaName, request.StoredProcedureName),
                    new { "@ZorgverzekeraarId": 409 },
                    commandType: CommandType.StoredProcedure);
            }
            */
            return response;
        }
    }
}
