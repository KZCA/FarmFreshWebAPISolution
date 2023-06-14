using FarmFresh.Business.Services;
using FarmFresh.DataAccess.Entity;
using FarmFresh.DataAccess.Repository;
using FarmFreshWebAPI.Model;
using FarmFreshWebAPI.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FarmFreshWebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    [Authorize]
    public class JWTAuthController : ControllerBase
    { 
        private readonly IJWTManager _jWTManager;
        private readonly IUserService _userService;
        public JWTAuthController(IJWTManager jWTManager, IUserService userService)
        {
            this._jWTManager = jWTManager;
            this._userService = userService;
        }

        [HttpGet("user")]
        public List<string> Get()
        {
            var users = new List<string>
        {
            "Satinder Singh",
            "Amit Sarna",
            "Davin Jon"
        };

            return users;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(Users usersdata)
        {
            Dictionary<string, string> UsersRecords = new Dictionary<string, string>
            {
                { "user1","password1"},
                { "user2","password2"},
                { "user3","password3"},
            };

            if (!UsersRecords.Any(x => x.Key == usersdata.Name && x.Value == usersdata.Password))
            {
                return Unauthorized("Incorrect username or password!");
            }

            var token = _jWTManager.GenerateToken(usersdata.Name);

            if (token == null)
            {
                return Unauthorized("Invalid Attempt!");
            }

            // saving refresh token to the db
            UserRefreshTokens obj = new UserRefreshTokens
            {
                RefreshToken = token.Refresh_Token,
                UserName = usersdata.Name
            };

            _userService.AddUserRefreshTokens(obj);
            
            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh(Tokens token)
        {
            var principal = _jWTManager.GetPrincipalFromExpiredToken(token.Access_Token);
            var username = principal.Identity?.Name;

            //retrieve the saved refresh token from database
            var savedRefreshToken = _userService.GetSavedRefreshTokens(username, token.Refresh_Token);

            if (savedRefreshToken.RefreshToken != token.Refresh_Token)
            {
                return Unauthorized("Invalid attempt!");
            }

            var newJwtToken = _jWTManager.GenerateRefreshToken(username);

            if (newJwtToken == null)
            {
                return Unauthorized("Invalid attempt!");
            }

            // saving refresh token to the db
            UserRefreshTokens obj = new UserRefreshTokens
            {
                RefreshToken = newJwtToken.Refresh_Token,
                UserName = username
            };

            _userService.DeleteUserRefreshTokens(username, token.Refresh_Token);
            _userService.AddUserRefreshTokens(obj);

            return Ok(newJwtToken);
        }
    }
}
