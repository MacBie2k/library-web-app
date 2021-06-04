using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApp.Models;
using LibraryWebApp.Models.Entities;
using LibraryWebApp.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApp.Controllers
{
    public class AdminController : Controller
    {
        private AdminService _adminService;
        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Authors()
        {
            var vm = new AuthorsListViewModel
            {
                Authors = _adminService.GetAllAuthors()
            };
            return View(vm);
        }
        public IActionResult Books()
        {
            var vm = new BooksListViewModel
            {
                Books = _adminService.GetAllBooks()
            };
            return View(vm);
        }
        public IActionResult AuthorsBooks(int id)
        {
            var vm = new BooksListViewModel
            {
                Books = _adminService.GetAuthorsBooks(id)
            };
            return View(vm);
        }
        public IActionResult Users()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAuthor(AuthorViewModel data)
        {

            if (!ModelState.IsValid)
            {
                return View(data);
            }
            _adminService.CreateAuthor(data.Firstname, data.LastName);

            return RedirectToAction("Authors");
        }

        [HttpGet]
        public IActionResult RemoveAuthor(int id)
        {
            _adminService.RemoveAuthor(id);
            return RedirectToAction("Authors");
        }
        [HttpGet]
        public IActionResult RemoveBook(int id)
        {
            _adminService.RemoveBook(id);
            return RedirectToAction("Authors");
        }

        [HttpGet]
        public IActionResult EditAuthor(int id)
        {
            var vm = _adminService.GetAuthorToEdit(id);
            return View(vm);
        }
        [HttpPost]
        public IActionResult EditAuthor(AuthorViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }
            _adminService.UpdateAuthor(data);
            return RedirectToAction("Authors");
        }
        [HttpGet]
        public IActionResult EditBook(int id)
        {
            var vm = _adminService.GetBookToEdit(id);
            return View(vm);
        }
        [HttpPost]
        public IActionResult EditBook(BookEntity data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }
            _adminService.UpdateBook(data);
            return RedirectToAction("Books");
        }
        [HttpGet]
        public IActionResult AddBook(int id)
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult AddBook(BookViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }
            _adminService.AddBook(data);
            return RedirectToAction("Authors");
        }

    }
}
