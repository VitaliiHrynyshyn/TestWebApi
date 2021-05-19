using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestWeb.Models;
using TestWeb.Persistence.Base;
using TestWeb.Persistence.Context;

namespace TestWeb.Persistence.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbSet<Category> _dbSet;
        private readonly ProductContext _context;
        public CategoryRepository(ProductContext context)
        {
            _dbSet = context.Set<Category>();
            _context = context;
        }

        public Task<List<Category>> GetAllAsync()
        {
            return _dbSet.ToListAsync();
        }
        
        public virtual Task<List<Category>> GetWithProductsAsync()
        {
            return _dbSet.Include(x=> x.Products).ToListAsync();
        }

        public Task<Category> GetByIdAsync(object id)
        {
            return _dbSet.FindAsync(id).AsTask();
        }
        public async Task<Category> AddAsync(Category obj)
        {
            if (obj == null)
                return null;

            var entity = await _dbSet.AddAsync(obj);
            return entity.Entity;
        }
        public Category Update(Category obj)
        {
            if (obj == null)
                return null;

            return _dbSet.Update(obj).Entity;
        }
        public async Task<Category> RemoveAsync(int id)
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
