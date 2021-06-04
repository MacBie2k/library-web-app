using LibraryWebApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Models
{
    public class AuthorBookViewModel
    {

        public BookEntity Books { get; set; }
        public AuthorEntity Authors { get; set; }

    }
}
