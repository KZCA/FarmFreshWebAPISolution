using FarmFresh.DataAccess.Data;
using FarmFresh.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.DataAccess.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {        

    }

    public class CategoryRepository: Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public CategoryRepository(ApplicationDBContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
        
    }
}
