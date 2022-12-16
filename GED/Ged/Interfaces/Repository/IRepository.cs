using Ged.Classes;
using System.Linq.Expressions;

namespace Ged.Interfaces.Repository
{
    public interface IRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> GetAsync(params Expression<Func<T, object>>[] joins);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> lambda, params Expression<Func<T, object>>[] joins);
        Task<T> GetFirstAsync(Expression<Func<T, bool>> lambda, params Expression<Func<T, object>>[] joins);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> lambda);
        Task AddAsync(T entity);
        Task AddCollectionAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateCollectionAsync(IEnumerable<T> entities);
        Task RemoveAsync(T entity);
        Task SaveChangesAsync();
        void SetInsertData(Entity entity);
    }
}
