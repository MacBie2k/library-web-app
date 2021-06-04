using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApp.Models;
using LibraryWebApp.Models.Entities;
using LibraryWebApp.Models.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApp.Controllers
{
    public class SignInController : Controller
    {
        private UserService _userService;
        private UserManager<CustomUser> _userManager;
        private SignInManager<CustomUser> _signInManager;
        public SignInController(UserService userService, SignInManager<CustomUser> signInManager, UserManager<CustomUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(LoginViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }
            var result = _signInManager.PasswordSignInAsync(data.Login, data.Password, false, false).Result;
           if(result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Nieprawidłowe dane");
            return View();
        }


        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel data)
        {

            if(!ModelState.IsValid)
            {
                return View(data);
            }
            //_userService.CreateUser(data.FirstName, data.LastName, data.Email, data.Login, data.Password, data.Zip, data.City, data.Street);
            var entity = new CustomUser
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                UserName = data.Login,

                Adress = new AdressEntity
                {
                    City = data.City,
                    Zip = data.Zip,
                    Street = data.Street
                }

            };
            var result = _userManager.CreateAsync(entity, data.Password).Result;
            if(result.Succeeded)
            {
                return RedirectToAction( "Index", "SignIn");
            }
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(data);
        }

    }
}
