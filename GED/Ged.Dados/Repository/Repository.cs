using Dapper;
using Ged.Classes;
using Ged.Interfaces.Factory;
using Ged.Interfaces.Repository;
using Npgsql;
using System.Data;
using System.Reflection;

namespace Ged.Dados.Repository
{
    public class Repository<T> : IRepository<T>, IDisposable where T : Entity
    {
        protected readonly NpgsqlConnection _dbConnection;
        protected NpgsqlTransaction? _dbTransaction;
        protected readonly IDatabaseFactory _databaseFactory;
        protected readonly IQuery _query;

        public Repository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
            _dbConnection = databaseFactory.GetDbConnection();
            _query = new Query<T>();
        }

        public void StartTransaction() => _dbTransaction = _databaseFactory.GetDbTransaction();

        public async Task<IEnumerable<T>> QueryAsync() => await _dbConnection.QueryAsync<T>(_query.SelectQuery(), transaction: _dbTransaction);

        public async Task<IEnumerable<T>> QueryAsync(object param) => await _dbConnection.QueryAsync<T>(_query.SelectQuery(param), param, transaction: _dbTransaction);

        public async Task<IEnumerable<T>> QueryAsync(object param, string orderBy) => await _dbConnection.QueryAsync<T>(_query.SelectQuery(param, orderBy), param, transaction: _dbTransaction);

        public async Task<IEnumerable<T>> QueryAsync(string sql) => await _dbConnection.QueryAsync<T>(sql, transaction: _dbTransaction);

        public async Task<IEnumerable<T>> QueryAsync(string sql, object param) => await _dbConnection.QueryAsync<T>(sql, param, transaction: _dbTransaction);

        public async Task<IEnumerable<T>> ProcedureAsync(string procedure, object param) => await _dbConnection.QueryAsync<T>(procedure, param, commandType: CommandType.StoredProcedure, transaction: _dbTransaction);

        public async Task<T> QueryFirstAsync(object param) => await _dbConnection.QueryFirstAsync<T>(_query.SelectQuery(param), param, transaction: _dbTransaction);

        public async Task<T> QueryFirstAsync(string sql, object param) => await _dbConnection.QueryFirstAsync<T>(sql, param, transaction: _dbTransaction);

        public virtual async Task<T> AddAsync(T obj)
        {
            obj.Id = await _dbConnection.QuerySingleAsync<long>(_query.SelectQuerySequence(), null, transaction: _dbTransaction);
            await _dbConnection.ExecuteAsync(_query.InsertQueryReturnInserted(), obj, transaction: _dbTransaction);
            return obj;
        }

        public virtual async Task<int> UpdateAsync(T obj) => await _dbConnection.ExecuteAsync(_query.UpdateByIdQuery(), obj, transaction: _dbTransaction);

        public bool ParameterHasValue(object parametro, string nome)
        {
            PropertyInfo? propriedade = parametro.GetType().GetProperty(nome);
            object? valor = propriedade?.GetValue(parametro);
            return !(valor == null || string.IsNullOrEmpty(valor.ToString()));
        }

        public object? ParameterValue(object parametro, string nome)
        {
            PropertyInfo? propriedade = parametro.GetType().GetProperty(nome);
            return propriedade?.GetValue(obj: parametro);
        }

        public void Dispose() => _databaseFactory.Dispose();
    }
}
