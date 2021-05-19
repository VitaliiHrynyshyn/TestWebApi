using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestWeb.Models;
using TestWeb.Persistence.Base;
using TestWeb.Persistence.Context;

namespace TestWeb.Persistence.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbSet<Product> _dbSet;
        private readonly ProductContext _context;
        public ProductRepository(ProductContext context)
        {
            _dbSet = context.Set<Product>();
            _context = context;
        }

        public Task<List<Product>> GetAllAsync()
        {
            return _dbSet.ToListAsync();
        }

        public Task<List<Product>> GetWithCategoryAsync()
        {

            return _dbSet.Include(x => x.Category)
                .ToListAsync();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            return _dbSet.FindAsync(id).AsTask();
        }
        public async Task<Product> AddAsync(Product obj)
        {
            if (obj == null)
                return null;

            var entity = await _dbSet.AddAsync(obj);
            return entity.Entity;
        }
        public Product Update(Product obj)
        {
            if (obj == null)
                return null;

            return _dbSet.Update(obj).Entity;
        }
        public async Task<Product> RemoveAsync(int id)
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
