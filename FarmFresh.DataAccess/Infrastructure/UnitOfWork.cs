using FarmFresh.DataAccess.Data;
using FarmFresh.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.DataAccess.Infrastructure
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepo { get; }
        IProductRepository ProductRepo { get; }
        IUserServiceRepository UserServiceRepo { get; }

        int Save();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDBContext dbContext;
        public ICategoryRepository CategoryRepo { get; set; }
        public IProductRepository ProductRepo { get; set; }
        public IUserServiceRepository UserServiceRepo { get; set; }

        public UnitOfWork(ApplicationDBContext dBContext)
        {
            dbContext = dBContext;
            CategoryRepo = new CategoryRepository(dbContext);
            ProductRepo = new ProductionRepository(dbContext);
            UserServiceRepo = new UserServiceRepository(dbContext);
        }

        public int Save()
        {
            return dbContext.SaveChanges();
        }
    }


}
