using LibraryWebApp.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Models.Services
{
    public class UserService
    {
        private LibraryDbContext _context;
        private AdminService _adminService;
        private UserManager<CustomUser> _userManager;
        public UserService(LibraryDbContext context, UserManager<CustomUser> userManager, AdminService adminService)
        {
            _context = context;
            _userManager = userManager;
            _adminService = adminService;
        }
        //public void CreateUser(string firstName, string lastName, string email, string login, string password, string zip, string city, string street)
        //{

        //}
        public IEnumerable<BookEntity> ShowBooks()
        {
            var books = _context.Books.ToList();
            return books;

        }
        public void AllInOne()
        {

        }

    }
}
