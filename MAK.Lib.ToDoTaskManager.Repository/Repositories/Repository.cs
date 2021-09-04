using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Database;

using Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class Repository<TEntity, TEntityID> : IRepository<TEntity, TEntityID> where TEntity : class where TEntityID : struct
    {
        public Repository(ApplicationDbContext applicationDbContext) => this.ApplicationDbContext = applicationDbContext;

        protected ApplicationDbContext ApplicationDbContext { get; set; }

        // S Accessors
        public IQueryable<TEntity> Get() => this.ApplicationDbContext.Set<TEntity>().AsNoTracking();

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate) => this.ApplicationDbContext.Set<TEntity>().Where(predicate).AsNoTracking();

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate) => await this.ApplicationDbContext.Set<TEntity>().FirstOrDefaultAsync(predicate);

        public async Task<IEnumerable<TEntity>> GetAsync() => await this.ApplicationDbContext.Set<TEntity>().AsNoTracking().ToListAsync();

        public async Task<ICollection<TEntity>> GetOrderByAsync() => await this.Get().OrderBy(t => t).ToListAsync();

        public async Task<ICollection<TEntity>> GetOrderByDescendingAsync() => await this.Get().OrderByDescending(t => t).ToListAsync();

        public async Task<TEntity> FindAsync(TEntityID id) => await this.ApplicationDbContext.Set<TEntity>().FindAsync(id);

        public async Task<bool> SuccessAsync(TEntityID id) => await this.FindAsync(id) != null;

        public async Task<bool> SuccessAsync(Expression<Func<TEntity, bool>> predicate) => (await this.ApplicationDbContext.Set<TEntity>().FirstOrDefaultAsync(predicate)) != null;
        // E Accessors

        // S Mutators
        public async Task PostRangeAsync(TEntity entity) => await this.ApplicationDbContext.Set<TEntity>().AddRangeAsync(entity);

        public async Task PutRangeAsync(TEntity entity)
        {
            this.ApplicationDbContext.Set<TEntity>().UpdateRange(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteRangeAsync(TEntity entity)
        {
            this.ApplicationDbContext.Set<TEntity>().RemoveRange(entity);
            await Task.CompletedTask;
        }
        // E Mutators
    }
}
