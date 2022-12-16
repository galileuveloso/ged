using Ged.Classes;
using Ged.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace Ged.Dados.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly IDbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        protected IQueryable<T> Query(params Expression<Func<T, object>>[] joins)
        {
            var query = _context
                .Set<T>()
                .AsQueryable();
            return joins == null ? query : joins.Aggregate(query, (current, include) => current.Include(include));
        }

        public virtual async Task<IEnumerable<T>> GetAsync(params Expression<Func<T, object>>[] joins)
        {
            return await Query(joins).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> lambda, params Expression<Func<T, object>>[] joins)
        {
            return await Query(joins)
                .Where(lambda)
                .ToListAsync();
        }

        public virtual async Task<T> GetFirstAsync(Expression<Func<T, bool>> lambda, params Expression<Func<T, object>>[] joins) => await Query(joins).FirstOrDefaultAsync(lambda);

        public virtual async Task<bool> ExistsAsync(Expression<Func<T, bool>> lambda)
        {
            return await Query().AnyAsync(lambda);
        }

        public virtual async Task AddAsync(T entity)
        {
            await _context
                .Set<T>()
                .AddAsync(entity)
                .ConfigureAwait(false);
        }

        public virtual async Task AddCollectionAsync(IEnumerable<T> entities)
        {
            await _context
                .Set<T>()
                .AddRangeAsync(SetAddData(entities))
                .ConfigureAwait(false);
        }

        public virtual Task UpdateAsync(T entity)
        {
            _context
                .Set<T>()
                .Update(SetUpdateData(entity));
            return Task.CompletedTask;
        }

        public virtual Task UpdateCollectionAsync(IEnumerable<T> entities)
        {
            _context
                .Set<T>()
                .UpdateRange(SetUpdateData(entities));
            return Task.CompletedTask;
        }

        public virtual Task RemoveAsync(T entity)
        {
            _context
                .Set<T>()
                .Remove(entity);
            return Task.CompletedTask;
        }

        public void SetInsertData(Entity entity)
        {
            entity.DataAtualizacao = null;
            entity.DataCadastro = DateTime.Now;
        }

        private T SetAddData(T entity)
        {
            SetInsertData(entity);
            return entity;
        }

        private T SetUpdateData(T entity)
        {
            entity.DataAtualizacao = DateTime.Now;
            return entity;
        }

        private IEnumerable<T> SetAddData(IEnumerable<T> entities)
        {
            return entities.Select(entity => { return SetAddData(entity); });
        }

        private IEnumerable<T> SetUpdateData(IEnumerable<T> entities)
        {
            return entities.Select(entity => { return SetUpdateData(entity); });
        }

        public virtual async Task SaveChangesAsync()
        {
            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);
        }
    }
}
