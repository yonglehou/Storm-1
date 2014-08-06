using Flyingpie.Storm.Executors;
using Flyingpie.Storm.Utility;
using global::Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Flyingpie.Storm.Dapper
{
    public class DapperSqlExecutor : ISqlExecutor
    {
        public string ConnectionString { get; private set; }

        private IDbConnection _connection;
        private IDbTransaction _transaction;

        private DapperSqlExecutor()
        {
        }

        public static DapperSqlExecutor FromConnectionString(string connectionString)
        {
            var executor = new DapperSqlExecutor();
            executor.ConnectionString = connectionString;
            return executor;
        }

        public static DapperSqlExecutor FromConnectionStringName(string connectionStringName)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[connectionStringName];

            if (connectionString == null)
            {
                throw new InvalidOperationException("No connection string found in config with name '" + connectionStringName + "'");
            }

            return FromConnectionString(connectionString.ConnectionString);
        }

        public T Execute<T>(SqlRequest request) where T : SqlResponse
        {
            var response = Activator.CreateInstance<T>();

            response.Execute(request, this);

            return response;
        }

        public IDbTransaction BeginTransaction()
        {
            CreateConnection();

            _transaction = _connection.BeginTransaction();

            return _transaction;
        }

        public int Query(SqlRequest request)
        {
            CreateConnection();

            var parameters = CreateParameters(request);

            var result = _connection.Query<int>(
                string.Format("{0}.{1}", request.SchemaName, request.StoredProcedureName),
                parameters,
                commandType: CommandType.StoredProcedure, transaction: _transaction);

            FetchParameterValue(request, parameters);

            return result.Any() ? result.First() : -1;
        }

        public IEnumerable<T> Query<T>(SqlRequest request)
        {
            CreateConnection();

            var parameters = CreateParameters(request);

            var result = _connection.Query<T>(
                string.Format("{0}.{1}", request.SchemaName, request.StoredProcedureName),
                parameters,
                commandType: CommandType.StoredProcedure,
                transaction: _transaction);

            return result;
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>> Query<T1, T2>(SqlRequest request)
        {
            CreateConnection();

            var parameters = CreateParameters(request);

            var results = _connection.QueryMultiple(
                string.Format("{0}.{1}", request.SchemaName, request.StoredProcedureName),
                parameters,
                commandType: CommandType.StoredProcedure,
                transaction: _transaction);

            var result1 = results.Read<T1>();
            var result2 = results.Read<T2>();

            return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(result1, result2);
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> Query<T1, T2, T3>(SqlRequest request)
        {
            CreateConnection();

            var parameters = CreateParameters(request);

            var results = _connection.QueryMultiple(
                string.Format("{0}.{1}", request.SchemaName, request.StoredProcedureName),
                parameters,
                commandType: CommandType.StoredProcedure,
                transaction: _transaction);

            var result1 = results.Read<T1>();
            var result2 = results.Read<T2>();
            var result3 = results.Read<T3>();

            return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>(result1, result2, result3);
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>> Query<T1, T2, T3, T4>(SqlRequest request)
        {
            CreateConnection();

            var parameters = CreateParameters(request);

            var results = _connection.QueryMultiple(
                string.Format("{0}.{1}", request.SchemaName, request.StoredProcedureName),
                parameters,
                commandType: CommandType.StoredProcedure,
                transaction: _transaction);

            var result1 = results.Read<T1>();
            var result2 = results.Read<T2>();
            var result3 = results.Read<T3>();
            var result4 = results.Read<T4>();

            return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>(result1, result2, result3, result4);
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>> Query<T1, T2, T3, T4, T5>(SqlRequest request)
        {
            CreateConnection();

            var parameters = CreateParameters(request);

            var results = _connection.QueryMultiple(
                string.Format("{0}.{1}", request.SchemaName, request.StoredProcedureName),
                parameters,
                commandType: CommandType.StoredProcedure,
                transaction: _transaction);

            var result1 = results.Read<T1>();
            var result2 = results.Read<T2>();
            var result3 = results.Read<T3>();
            var result4 = results.Read<T4>();
            var result5 = results.Read<T5>();

            return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>(result1, result2, result3, result4, result5);
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>> Query<T1, T2, T3, T4, T5, T6>(SqlRequest request)
        {
            CreateConnection();

            var parameters = CreateParameters(request);

            var results = _connection.QueryMultiple(
                string.Format("{0}.{1}", request.SchemaName, request.StoredProcedureName),
                parameters,
                commandType: CommandType.StoredProcedure,
                transaction: _transaction);

            var result1 = results.Read<T1>();
            var result2 = results.Read<T2>();
            var result3 = results.Read<T3>();
            var result4 = results.Read<T4>();
            var result5 = results.Read<T5>();
            var result6 = results.Read<T6>();

            return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>(result1, result2, result3, result4, result5, result6);
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>> Query<T1, T2, T3, T4, T5, T6, T7>(SqlRequest request)
        {
            CreateConnection();

            var parameters = CreateParameters(request);

            var results = _connection.QueryMultiple(
                string.Format("{0}.{1}", request.SchemaName, request.StoredProcedureName),
                parameters,
                commandType: CommandType.StoredProcedure,
                transaction: _transaction);

            var result1 = results.Read<T1>();
            var result2 = results.Read<T2>();
            var result3 = results.Read<T3>();
            var result4 = results.Read<T4>();
            var result5 = results.Read<T5>();
            var result6 = results.Read<T6>();
            var result7 = results.Read<T7>();

            return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>(result1, result2, result3, result4, result5, result6, result7);
        }

        private void CreateConnection()
        {
            // The connection seems to be null every time and it needs to be opened every request, not very speedy
            if (_connection == null || _connection.State == ConnectionState.Closed || _connection.State == ConnectionState.Broken)
            {
                _connection = new SqlConnection(ConnectionString);
            }

            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
        }

        private DynamicParameters CreateParameters(SqlRequest request)
        {
            var parameters = new DynamicParameters();

            foreach (var parameter in request.Parameters)
            {
                var simple = parameter as StoredProcedureSimpleParameter;

                if (simple != null)
                {
                    parameters.Add(simple.Name, simple.Value, direction: simple.Mode);
                    continue;
                }

                var table = parameter as StoredProcedureTableTypeParameter;

                if (table != null)
                {
                    var typeName = string.Format("{0}.{1}", table.SchemaName, table.UdtName);
                    parameters.Add(table.Name, table.Table.ToDataTable(typeName).AsTableValuedParameter(typeName));
                    continue;
                }

                throw new InvalidOperationException("Invalid parameter type: " + parameter.GetType());
            }

            return parameters;
        }

        private void FetchParameterValue(SqlRequest request, DynamicParameters parameters)
        {
            request
                .Parameters
                .Select(p => p as StoredProcedureSimpleParameter) // We need simple parameters
                .Where(p => p != null) // Non-simple parameters cannot be cast and shall be null
                .ToList()
                .ForEach(p => p.Value = parameters.Get<object>(p.Name)) // Retrieve the new parameter value from the executed stored proc
            ;
            /*

            foreach (var parameter in request.Parameters)
            {
                var simple = parameter as StoredProcedureSimpleParameter;

                if (simple != null)
                {
                    simple.Value = parameters.Get<object>(parameter.Name);
                    continue;
                }
            }
             */
        }
    }
}