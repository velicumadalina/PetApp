using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetApp.Models;

namespace PetApp.Controllers
{
    public class UserController : Controller
    {
        private UserManager<PetAppUser> _userManager;
            private SignInManager<PetAppUser> _signInManager;

        public UserController(UserManager<PetAppUser> userManager, SignInManager<PetAppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [Route("/register")]
        public IActionResult Register()
        {
            return View();
        }

        [Route("/register-user")]
        public async Task<IActionResult> Register(string username, string email, string first, string last, string psw) 
        {
            try
            {
                ViewBag.Message = "User Already Registered!";
                PetAppUser user = await _userManager.FindByNameAsync(username);
                if (user == null) 
                {
                    user = new PetAppUser();
                    user.UserName = username;
                    user.Email = email;
                    user.FirstName = first;
                    user.LastName = last;
                    IdentityResult result = await _userManager.CreateAsync(user, psw);
                    ViewBag.Message = "User created!";
                }
            }
            catch { }
            return RedirectToAction("Login");
        }
        [Route("/logout")]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Route("/login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("/profile")]
        public IActionResult Profile()
        {
            return View();
        }

        [Route("/login-user")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null) 
            {
                await _signInManager.PasswordSignInAsync(user, password, true, false);
                return RedirectToAction("Index", "Home");

            }

            return RedirectToAction("Register");
        }

    }
}
