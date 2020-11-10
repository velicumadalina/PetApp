using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetApp.Data;
using PetApp.Models;

namespace PetApp.Controllers
{
    public class UserController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private PetAppDbContext _context;
        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, PetAppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }


        [Route("/register")]
        public IActionResult Register()
        {
            return View();
        }

        [Route("/register-user")]
        public async Task<IActionResult> Register(string username, string email, string first, string last, bool isShelter,string psw)
        {
            try
            {
                ViewBag.Message = "User Already Registered!";
                User user = await _userManager.FindByNameAsync(username);
                if (user == null)
                {
                    user = new User();
                    user.UserName = username;
                    user.Email = email;
                    user.FirstName = first;
                    user.LastName = last;
                    user.IsShelter = isShelter;
                    IdentityResult result = await _userManager.CreateAsync(user, psw);
                    ViewBag.Message = "User created!";
                }
                if (isShelter)
                {
                    return Redirect("/register-shelter/" + user.UserName);
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
            var isShelter = _context.appUsers.Where(u => u.UserName == User.Identity.Name).FirstOrDefault().IsShelter;
            if (isShelter)
            {
                return RedirectToAction("ShelterProfile");
            }
            return View();
        }

        [Route("/shelter-profile")]
        public IActionResult ShelterProfile()
        {
            return View();
        }


        [Route("/login-user")]
        public async Task<IActionResult> LoginUser(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                await _signInManager.PasswordSignInAsync(user, password, true, false);
                return RedirectToAction("Index", "Home");

            }

            return RedirectToAction("Register");
        }

        [Route("/register-shelter/{userName}")]
        public IActionResult RegisterShelter(string userName)
        {
            var user = _context.appUsers.Where(u => u.UserName == userName).FirstOrDefault();
            return View(user);
        }
    }
}
