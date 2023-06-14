using FarmFresh.DataAccess.Entity;
using FarmFresh.DataAccess.Infrastructure;
using FarmFreshWebAPI.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Business.Services
{
    public interface IUserService
    {
        UserRefreshTokens AddUserRefreshTokens(UserRefreshTokens user);

        UserRefreshTokens GetSavedRefreshTokens(string username, string refreshtoken);

        void DeleteUserRefreshTokens(string username, string refreshToken);
    }
    public class UserService:IUserService
    {
        private readonly IUnitOfWork _uow;
        public UserService(IUnitOfWork uow) 
        { 
            _uow = uow;
        }

        public UserRefreshTokens AddUserRefreshTokens(UserRefreshTokens user)
        {
            _uow.UserServiceRepo.Add(user);
            _uow.Save();
            return user;
        }

        public void DeleteUserRefreshTokens(string username, string refreshToken)
        {
            var item = _uow.UserServiceRepo.Query(x => x.UserName == username && x.RefreshToken == refreshToken);
            if (item != null)
            {
                _uow.UserServiceRepo.Delete(item);
               _uow.Save();
            }
        }

        public UserRefreshTokens GetSavedRefreshTokens(string username, string refreshToken)
        {
            return _uow.UserServiceRepo.Query(x => x.UserName == username && x.RefreshToken == refreshToken && x.IsActive == true);
            
        } 
        
    }
}
