using Library.Entities.Enums;
using Library.Entities.Models;
using Library.ViewModels.Account;
using Library.WEB.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.WEB.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        [ActionName("Logout")]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpPost]
        [ActionName("Login")]
        public async Task<IActionResult> Login([FromBody]LoginAccountViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (!result.Succeeded)
            {
                return BadRequest(Errors.AddErrorToModelState("login_failure", "Invalid username or password.", ModelState));
            }
            User user = await _userManager.FindByEmailAsync(model.Email);
            var isAdmin = await _userManager.IsInRoleAsync(user, Roles.Admin.ToString().ToLower());

            return Ok(isAdmin);
        }

        [HttpPost]
        [ActionName("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterAccountViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new User();
            user.Name = model.Name;
            user.Email = model.Email;
            user.UserName = model.Email;
            IdentityResult resultUser = await _userManager.CreateAsync(user, model.Password);
            if (resultUser.Succeeded)
            {
                var roleUser = Roles.User.ToString().ToLower();
                await _userManager.AddToRoleAsync(user, roleUser);
            }
            if (!resultUser.Succeeded)
            {
                return new BadRequestObjectResult(Errors.AddErrorsToModelState(resultUser, ModelState));
            }

            return new OkObjectResult("Account created");
        }
    }
}
