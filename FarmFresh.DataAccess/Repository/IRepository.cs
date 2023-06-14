using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.DataAccess.Repository
{
    public interface IRepository<T> where T : class
    {  
        T Query(Func<T, Boolean> where);
        //Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties));
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null);
        Task<T> GetById(long id);       

		//Task<IEnumerable<T>> GetAll(Func<Product, bool> value);
        Task Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
