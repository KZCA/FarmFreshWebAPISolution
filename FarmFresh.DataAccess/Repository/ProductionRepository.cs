using FarmFresh.DataAccess.Data;
using FarmFresh.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FarmFresh.DataAccess.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        IList<Product> GetAllByInclude();
    }
    public class ProductionRepository: Repository<Product>, IProductRepository
    {
        private ApplicationDBContext _dbContext;
        public ProductionRepository(ApplicationDBContext contex):base(contex)
        {
            _dbContext = contex;
        }

        public IList<Product> GetAllByInclude()
        {
            return _dbContext.Products.OrderByDescending(p=>p.Id).Include(p=>p.Category).ToList();
        }

        
    }
}
