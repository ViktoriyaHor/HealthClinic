using HealthClinic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HealthClinic.Controllers
{

    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;
        private readonly ILogger<AccountController> _logger;


        public AccountController(UserManager<AppUser> userMgr, SignInManager<AppUser> signinMgr, ILogger<AccountController> logger)
        {
            userManager = userMgr;
            signInManager = signinMgr;
            _logger = logger;
        }


        [AllowAnonymous]
        public IActionResult Login(string returnUrl = "")
        {
            string defaultReturnUrl = "/";

            // Use null-coalescing operator to set the default URL if returnUrl is null or empty
            Login login = new Login
            {
                ReturnUrl = string.IsNullOrWhiteSpace(returnUrl) ? defaultReturnUrl : returnUrl
            };

            return View(login);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = await userManager.FindByEmailAsync(login.Email);
                if (appUser != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(appUser, login.Password, login.Remember, false);
                    if (result.Succeeded)
                        if (await userManager.IsInRoleAsync(appUser, "Admin"))
                        {
                            return RedirectToAction("Admin", "Home");
                        }
                        else if (string.IsNullOrWhiteSpace(login.ReturnUrl) || !Url.IsLocalUrl(login.ReturnUrl))
                        {
                            return Redirect("/");
                        }
                        else
                        {
                            _logger.LogInformation($"ReturnUrl: '{login.ReturnUrl}'");
                            return Redirect(login.ReturnUrl);
                        }
                }
                ModelState.AddModelError(nameof(login.Email), "Login Failed: Invalid Email or password");
            }
            return View(login);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
