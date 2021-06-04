using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LibraryWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using LibraryWebApp.Models.Services;

namespace LibraryWebApp.Controllers
{

    public class HomeController : Controller
    {
        private AdminService _adminService;
        public HomeController(AdminService adminService)
        {
            _adminService = adminService;
        }
        

        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult AllBooks()
        {
            var vm1 = new BooksListViewModel
            {
                Books = _adminService.GetAllBooks()
            };
            
            return View(vm1);
        }
        public IActionResult BorrowBook(int id)
        {

            return View();
        }
        
    }
}
