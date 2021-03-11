using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestWeb.Data.Context;
using TestWeb.Repositories.Interfaces;

namespace TestWeb.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        private readonly ProductContext _context;
        public GenericRepository(ProductContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }

        public Task<List<T>> GetAllAsync()
        {
            return _dbSet.ToListAsync();
        }
        
        public virtual Task<List<T>> GetAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return orderBy != null ? orderBy(query).ToListAsync() : query.ToListAsync();
        }

        public Task<T> GetByIdAsync(object id)
        {
            return _dbSet.FindAsync(id).AsTask();
        }
        public async Task<T> AddAsync(T obj)
        {
            if (obj == null)
                return null;

            var entity = await _dbSet.AddAsync(obj);
            return entity.Entity;
        }
        public T Update(T obj)
        {
            if (obj == null)
                return null;

            return _dbSet.Update(obj).Entity;
        }
        public async Task<T> RemoveAsync(int id)
        {
            var obj = await _dbSet.FindAsync(id);

            if (obj == null)
                return null;

            return _dbSet.Remove(obj).Entity;

        }
        public async Task SaveAsync()
        {
            var hasChanges = _context.ChangeTracker.HasChanges();
            if (hasChanges)
            {
                await _context.SaveChangesAsync();
            }
        }
    }
}
