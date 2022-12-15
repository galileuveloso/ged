using Npgsql;
using System.Data;

namespace Ged.Interfaces.Factory
{
    public interface IDatabaseFactory
    {
        NpgsqlConnection GetDbConnection();
        NpgsqlTransaction GetDbTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void Dispose();
    }
}
