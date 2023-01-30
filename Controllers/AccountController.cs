using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyEticketApplication.Models;

namespace MyEticketApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(UserRegistration userRegistration)
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = userRegistration.Email,
                    PhoneNumber= userRegistration.PhoneNumber,
                    Email = userRegistration.Email,
                };
                var result = await _userManager.CreateAsync(user, userRegistration.Password);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(userRegistration);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "home");
        }     
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password,userLogin.RememberMe, false);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty,"Invalid Login Attempt!");
            }
            return View(userLogin);
        }

    }

}
