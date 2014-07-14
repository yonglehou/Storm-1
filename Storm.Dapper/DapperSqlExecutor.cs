using Flyingpie.Storm.Lib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using global::Dapper;
using System.Reflection;
using System.Collections;

namespace Storm.Dapper
{
    public class DapperSqlExecutor : ISqlExecutor
    {
        private string _connectionString;

        public DapperSqlExecutor(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Query(SqlRequest request)
        {
            using (var connection = CreateConnection())
            {
                var parameters = CreateParameters(request);

                var result = connection.Execute(
                    string.Format("{0}.{1}", request.SchemaName, request.StoredProcedureName),
                    parameters,
                    commandType: CommandType.StoredProcedure);

                FetchParameterValue(request, parameters);

                return result;
            }
        }
        // Can we move this? Seems non-specific
        public T Execute<T>(SqlRequest request) where T : SqlResponse
        {
            var response = Activator.CreateInstance<T>();

            response.Execute(request, this);

            return response;
        }

        public IEnumerable<T> Query<T>(SqlRequest request)
        {
            using (var connection = CreateConnection())
            {
                var parameters = CreateParameters(request);

                var result = connection.Query<T>(
                    string.Format("{0}.{1}", request.SchemaName, request.StoredProcedureName),
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>> Query<T1, T2>(SqlRequest request)
        {
            using (var connection = CreateConnection())
            {
                var parameters = CreateParameters(request);

                var results = connection.QueryMultiple(
                    string.Format("{0}.{1}", request.SchemaName, request.StoredProcedureName),
                    parameters,
                    commandType: CommandType.StoredProcedure);

                var result1 = results.Read<T1>();
                var result2 = results.Read<T2>();

                return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(result1, result2);
            }
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> Query<T1, T2, T3>(SqlRequest request)
        {
            using (var connection = CreateConnection())
            {
                var parameters = CreateParameters(request);

                var results = connection.QueryMultiple(
                    string.Format("{0}.{1}", request.SchemaName, request.StoredProcedureName),
                    parameters,
                    commandType: CommandType.StoredProcedure);

                var result1 = results.Read<T1>();
                var result2 = results.Read<T2>();
                var result3 = results.Read<T3>();

                return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>(result1, result2, result3);
            }
        }

        private SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        private DynamicParameters CreateParameters(SqlRequest request)
        {
            var parameters = new DynamicParameters();

            foreach (var parameter in request.Parameters)
            {
                var simple = parameter as StoredProcedureSimpleParameter;

                if (simple != null)
                {
                    parameters.Add(simple.Name, simple.Value, direction: ParameterDirection.InputOutput);
                    continue;
                }

                var table = parameter as StoredProcedureTableTypeParameter;

                if (table != null)
                {
                    parameters.Add(table.Name, table.Table.ToDataTable(string.Format("{0}.{1}", table.SchemaName, table.UdtName)));
                    continue;
                }

                throw new InvalidOperationException("Invalid parameter type: " + parameter.GetType());
            }

            return parameters;
        }

        private void FetchParameterValue(SqlRequest request, DynamicParameters parameters)
        {
            foreach (var parameter in request.Parameters)
            {
                var simple = parameter as StoredProcedureSimpleParameter;

                if (simple != null)
                {
                    //TODO: Check direction
                    simple.Value = parameters.Get<object>(parameter.Name);
                    continue;
                }
            }
        }
    }
}
