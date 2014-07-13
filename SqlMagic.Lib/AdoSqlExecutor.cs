﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Flyingpie.Storm.Lib
{
    public class AdoSqlExecutor : ISqlExecutor
    {
        public SqlResponse Execute(SqlRequest request)
        {
            var response = new SqlResponse();

            using (var connection = new SqlConnection("server=DBCS_PRD_SQLSRV;database=DBCServices5;integrated security=true;"))
            using (var command = new SqlCommand(request.SchemaName + "." + request.StoredProcedureName, connection)
            { CommandType = CommandType.StoredProcedure })
            {
                foreach (var parameter in request.Parameters)
                {
                    var sp = (StoredProcedureSimpleParameter)parameter; //TODO: Whot?
                    var p = command.Parameters.Add(new SqlParameter(sp.Name, sp.Value != null ? sp.Value : DBNull.Value) { Direction = ParameterDirection.Input });
                }

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(4));
                }
            }

            return response;
        }
    }
}
