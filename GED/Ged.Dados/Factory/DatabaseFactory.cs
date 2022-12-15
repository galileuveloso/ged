using Ged.Interfaces.Factory;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace Ged.Dados.Factory
{
    public class DatabaseFactory : IDatabaseFactory, IDisposable
    {
        private readonly IConfiguration _configuration;
        private readonly NpgsqlConnection _dbConnection;
        private NpgsqlTransaction? _transaction;

        public DatabaseFactory(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("DbContext"));
            if (_dbConnection.State != ConnectionState.Open)
                _dbConnection.Open();
        }

        public void Dispose()
        {
            _dbConnection.Close();
            _dbConnection.Dispose();
        }

        public NpgsqlConnection GetDbConnection() => _dbConnection;

        public NpgsqlTransaction GetDbTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (_transaction != null && _transaction.Connection != null)
                return _transaction;

            _transaction = _dbConnection.BeginTransaction(isolationLevel);

            return _transaction;
        }
    }
}
