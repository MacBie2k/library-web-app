﻿using LibraryWebApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Models
{
    public class AuthorsListViewModel
    {
        public IEnumerable<AuthorEntity> Authors { get; set; }
    }
}
