using BellaPizza.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BellaPizza.Controllers
{
    public class AccountController : Controller
    {
        readonly SignInManager<BellaUser> signInManager;
        readonly UserManager<BellaUser> userManager;

        public AccountController(SignInManager<BellaUser> signInManager, UserManager<BellaUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            BellaUser bellaUser = await userManager.FindByEmailAsync(email);

            var result = await signInManager.PasswordSignInAsync(bellaUser, password, true, true);

            if (result.Succeeded)
            {
                return RedirectToAction("SignUp");
            }

            return View();
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(string firstname, string lastname, string email, string password, string repeatpassword)
        {
            BellaUser user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                BellaUser bellaUser = new BellaUser()
                {
                    Email = email,
                    UserName = firstname,
                };

                var result = userManager.CreateAsync(bellaUser).Result;

                if (result.Succeeded)
                {
                    result = userManager.AddPasswordAsync(user, password).Result;
                }
            }
            return View();
        }



    }
}
