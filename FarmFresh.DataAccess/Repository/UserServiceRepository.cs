using FarmFresh.DataAccess.Data;
using FarmFresh.DataAccess.Entity;
using FarmFreshWebAPI.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.DataAccess.Repository
{
    public interface IUserServiceRepository:IRepository<UserRefreshTokens>
    {       
       
    }
    public class UserServiceRepository:Repository<UserRefreshTokens>, IUserServiceRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public UserServiceRepository(ApplicationDBContext dBContext):base(dBContext)
        {
            _dbContext = dBContext;
        }        

    }
}
