﻿using Dingo.ViewModels;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dingo.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

        }

        #region Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(LoginVM login)
        {
            AppUser? user = await userManager.FindByEmailAsync(login.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Email yaxud Şifrə yanlışdır");
                return View();
            }
            if (user.IsDeacive)
            {
                ModelState.AddModelError("", "Sizin hesabınız admin tərəfdən bloklanıb");
                return View();
            }

            Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, login.Password,true,true);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Email yaxud şifrə yanlışdır");
                return View();
            }

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Sizin hesabınız qısa müddətlik bloklanıb. 1 dəqiqə sonra yenidən yoxlayın");
                return View();
            }

            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Logout
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}
