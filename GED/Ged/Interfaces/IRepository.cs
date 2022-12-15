using Ged.Classes;
using System.Threading.Tasks;

namespace Ged.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> QueryAsync();
        Task<IEnumerable<T>> QueryAsync(object param);
        Task<IEnumerable<T>> QueryAsync(object param, string orderBy);
        Task<IEnumerable<T>> QueryAsync(string sql);
        Task<IEnumerable<T>> QueryAsync(string sql, object param);
        Task<T> QueryFirstAsync(object param);
        Task<T> QueryFirstAsync(string sql, object param);
        Task<T> AddAsync(T obj);
        Task<int> UpdateAsync(T obj);
        bool ParameterHasValue(object parametro, string nome);
        void Dispose();
    }
}
