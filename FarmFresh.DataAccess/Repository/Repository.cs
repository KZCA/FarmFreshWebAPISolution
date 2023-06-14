using FarmFresh.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDBContext _dbContext;
        private DbSet<T> _dbSet;
        public Repository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<T> GetById(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        //public async Task<IEnumerable<T>> GetAll(Func<Product, bool> value)
        //{
        //    return await _dbContext.Set<T>().ToListAsync();
        //}

        public async Task Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
        public T Query(Func<T, Boolean> where)
        {
            IQueryable<T> query = _dbSet;
            return query.Where(where).FirstOrDefault();
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> dbQuery = _dbContext.Set<T>();
            if (filter != null)
                return dbQuery.Where(filter);
            return dbQuery;
        }

    }

}

