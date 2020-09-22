using FCPark.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Serilog;

namespace FCPark.DAL
{
    public class RepositoryBaseEF<T> : IRepository<T> where T : class
    {
        protected readonly FCParkDbContext _context;
        public RepositoryBaseEF(FCParkDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity)
        {
            Log.Information("AddAsync Method Called from {0}", entity.GetType().Name);
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            Log.Information("AddRangeAsync Method Called from {0}", entities.GetType().Name);
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            Log.Information("Find Method Called from {0}", predicate.GetType().Name);
            return _context.Set<T>().Where(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            Log.Information("GetAllAsync Method Called from {0}", this.GetType().Name);
            return await _context.Set<T>().ToListAsync();
        }

        public ValueTask<T> GetByIdAsync(int id)
        {
            Log.Information("GetByIdAsync Method Called from {0}", this.GetType().Name);
            return _context.Set<T>().FindAsync(id);
        }

        public void Remove(T entity)
        {
            Log.Information("Remove Method Called from {0}", this.GetType().Name);
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Log.Information("RemoveRange Method Called from {0}", this.GetType().Name);
            _context.Set<T>().RemoveRange(entities);
        }

        public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            Log.Information("SingleOrDefaultAsync Method Called from {0}", this.GetType().Name);
            return _context.Set<T>().SingleOrDefaultAsync(predicate);
        }
    }
}
