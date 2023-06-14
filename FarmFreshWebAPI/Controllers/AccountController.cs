using FarmFresh.DataAccess.Entity;
using FarmFreshWebAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FarmFreshWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;            
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(Users user)
        {
            AppUser newuser = new AppUser { UserName = user.Name, Email = user.Email };
            IdentityResult result = await _userManager.CreateAsync(newuser, user.Password);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(Users loginuser)
        {
            var result = await _signInManager.PasswordSignInAsync(loginuser.Name, loginuser.Password, false, false);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }

		[HttpPost("logout")]
		public async Task<IActionResult> Logout()
		{
            await _signInManager.SignOutAsync();

            return Ok();
		}
	}
}
