using Flyingpie.Storm.Execution;
using Flyingpie.Storm.Execution.Parameters;
using Flyingpie.Storm.Utility;
using global::Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Flyingpie.Storm.Dapper
{
    public class DapperSqlExecutor : ISqlExecutor, IDisposable
    {
        public string ConnectionString { get; private set; }

        private IDbConnection _connection;
        private IDbTransaction _transaction;

        public DapperSqlExecutor(DapperConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString();
        }

        public IDbTransaction BeginTransaction()
        {
            CreateConnection();

            _transaction = _connection.BeginTransaction();

            return _transaction;
        }

        public void NonQuery(ISqlRequest request)
        {
            CreateConnection();

            var parameters = CreateParameters(request);

            var result = _connection.Query<int>(
                string.Format("{0}.{1}", request.SchemaName, request.StoredProcedureName),
                parameters,
                commandType: CommandType.StoredProcedure, transaction: _transaction);

            FetchParameterValue(request, parameters);
        }

        public T Scalar<T>(ISqlRequest request)
        {
            CreateConnection();

            var parameters = CreateParameters(request);

            var result = _connection.Query<T>(
                string.Format("{0}.{1}", request.SchemaName, request.StoredProcedureName),
                parameters,
                commandType: CommandType.StoredProcedure, transaction: _transaction);

            FetchParameterValue(request, parameters);

            return result.Any() ? result.First() : default(T);
        }

        public IEnumerable<T> Query<T>(ISqlRequest request)
        {
            CreateConnection();

            var parameters = CreateParameters(request);

            var result = _connection.Query<T>(
                string.Format("{0}.{1}", request.SchemaName, request.StoredProcedureName),
                parameters,
                commandType: CommandType.StoredProcedure,
                transaction: _transaction);

            FetchParameterValue(request, parameters);

            return result;
        }

        public IMultipleResultSetReader Multiple(ISqlRequest request)
        {
            CreateConnection();

            var parameters = CreateParameters(request);

            var reader = _connection.QueryMultiple(
                string.Format("{0}.{1}", request.SchemaName, request.StoredProcedureName),
                parameters,
                commandType: CommandType.StoredProcedure,
                transaction: _transaction);

            FetchParameterValue(request, parameters);

            return new MultipleResultSetReader(reader);
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

        private DynamicParameters CreateParameters(ISqlRequest request)
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

        private void FetchParameterValue(ISqlRequest request, DynamicParameters parameters)
        {
            request
                .Parameters
                .Select(p => p as StoredProcedureSimpleParameter) // We need simple parameters
                .Where(p => p != null) // Non-simple parameters cannot be cast and shall be null
                .ToList()
                .ForEach(p => p.Value = parameters.Get<object>(p.Name)) // Retrieve the new parameter value from the executed stored proc
            ;
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }
    }
}