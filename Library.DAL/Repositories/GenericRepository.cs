using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Library.DAL.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository()
        {
            _context = new LibraryDb();
            _dbSet = _context.Set<TEntity>();
        }

        public void Add(TEntity item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public void Add(List<TEntity> items)
        {
            _dbSet.AddRange(items);
            _context.SaveChanges();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            var result = _dbSet.AsNoTracking().ToList();
            return result;
        }

        public IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbSet.AsQueryable();
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public List<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbSet.Where(predicate);
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).ToList();
        }

        public void Remove(int id)
        {
            var item = _dbSet.Find(id);
            if (item != null)
            {
                _dbSet.Remove(item);
                _context.SaveChanges();
            }
        }

        public virtual void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual void Update(List<TEntity> items)
        {
            foreach (var item in items)
            {
                _context.Entry(item).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }
    }
}
