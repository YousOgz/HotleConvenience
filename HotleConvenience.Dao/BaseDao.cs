using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotleConvenience.Dao
{
    public class BaseDao<T> : IBaseDao<T> where T : class, new()
    {
        private HCContext _context;

        private DbSet<T> _dbSet;

        public BaseDao(HCContext context)
        {
            this._context = context;
            this._dbSet = context.Set<T>();
        }

        public async Task<bool> AddAsync(IEnumerable<T> entities, bool isCommit = true)
        {
            await _dbSet.AddRangeAsync(entities);
            return isCommit ? await SaveAsync() : false;
        }

        public async Task<bool> AddAsync(T entity, bool isCommit = true)
        {
            await _dbSet.AddAsync(entity);
            return isCommit ? await SaveAsync() : false;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> where)
        {
            return await _dbSet.AnyAsync(where);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> where)
        {
            return await _dbSet.CountAsync(where);
        }

        public async Task<bool> DeleteAsync(T entity, bool isCommit = true)
        {
            _dbSet.Remove(entity);
            return isCommit ? await SaveAsync() : false;
        }

        public async Task<bool> DeleteAsync(IEnumerable<T> entities, bool isCommit = true)
        {
            _dbSet.RemoveRange(entities);
            return isCommit ? await SaveAsync() : false;
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> where)
        {
            return await _dbSet.FirstOrDefaultAsync(where);
        }

        public IQueryable<T> GetPaging(Expression<Func<T, bool>> where, int pageNum = 1, int pageSize = 10)
        {
            return _dbSet.Where(where).Skip((pageNum - 1) * pageSize).Take(pageSize);
        }

        public IQueryable<T> GetPaging(Expression<Func<T, bool>> where, Expression<Func<T, T>> orderBy, bool IsAsc = false, int pageNum = 1, int pageSize = 10)
        {
            return IsAsc ? _dbSet.Where(where).OrderBy(orderBy).Skip((pageNum - 1) * pageSize).Take(pageSize)
                        : _dbSet.Where(where).OrderByDescending(orderBy).Skip((pageNum - 1) * pageSize).Take(pageSize);
        }

        public async Task<double> LongCountAsync(Expression<Func<T, bool>> where)
        {
            return await _dbSet.LongCountAsync(where);
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<bool> UpdateAsync(T entities, bool isCommit = true)
        {
            var entry = _context.Entry(entities);
            if (entry.State == EntityState.Detached)
            {
                _dbSet.Attach(entities);
                entry.State = EntityState.Modified;
            }
            return isCommit ? await SaveAsync() : false;
        }

    }
}
