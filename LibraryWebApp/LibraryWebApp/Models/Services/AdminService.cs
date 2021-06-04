using LibraryWebApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Models.Services
{
    public class AdminService
    {
        private LibraryDbContext _context;

        public AdminService(LibraryDbContext context)
        {
            _context = context;
        }
        public void CreateAuthor(string firstName, string lastName)
        {
            var entity = new AuthorEntity
            {
                FirstName = firstName,
                LastName = lastName,
                Books = new List<BookEntity>()
                
            };
            _context.Add(entity);
            _context.SaveChanges();
        }
        public IEnumerable<AuthorEntity> GetAllAuthors()
        {
            var users = _context.Authors.ToList();
            return users;


        }
        public IEnumerable<BookEntity> GetAllBooks()
        {
            var books = _context.Books.ToList();
            return books;

        }
        public IEnumerable<BookEntity> GetAuthorsBooks(int id)
        {
            var books = _context.Books.Where(x => x.AuthorEntityId == id).ToList();
            return books;

        }
        public void RemoveAuthor(int id)
        {
            var author = _context.Authors.Find(id);
            _context.Authors.Remove(author);
           // RemoveAuthorsBooks(id);
            _context.SaveChanges();
        }
        public void RemoveAuthorsBooks(int id)
        {
            var author = _context.Authors.Find(id);
            foreach (var item in _context.Books)
            {
                if(author.Books.Contains(item))
                {
                    _context.Books.Remove(item);

                }
            }
            _context.SaveChanges();
        }
        public void RemoveBook(int id)
        {
            var book = _context.Books.Find(id);
            _context.Remove(book);

            _context.SaveChanges();
        }
        public AuthorViewModel GetAuthorToEdit(int id)
        {
            var author = _context.Authors.Find(id);
            var vm = new AuthorViewModel
            {
                Id = author.Id,
                Firstname = author.FirstName,
                LastName = author.LastName,

            };
            return vm;
        }

        public void UpdateAuthor(AuthorViewModel updated)
        {
            var author = _context.Authors.Find(updated.Id);
            author.FirstName = updated.Firstname;
            author.LastName = updated.LastName;
            _context.Update(author);
            _context.SaveChanges();
        }

        public void AddBook(BookViewModel updated)
        {
            var entity = new BookEntity
            {
                Name = updated.Name,
                AuthorEntityId = updated.Id

            };
            _context.Add(entity);
            _context.SaveChanges();

        }
        public BookEntity GetBookToEdit(int id)
        {
            var book = _context.Books.Find(id);
            var vm = new BookEntity
            {
                Id = book.Id,
                Name = book.Name,
                AuthorEntityId = book.AuthorEntityId

            };
            return vm;
        }

        public void UpdateBook(BookEntity updated)
        {
            var book = _context.Books.Find(updated.Id);
            book.Name = updated.Name;
            _context.Update(book);
            _context.SaveChanges();
        }

    }
}
