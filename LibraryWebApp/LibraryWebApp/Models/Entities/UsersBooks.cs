using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Models.Entities
{
    public class UsersBooks
    {
        public int Id { get; set; }

        [ForeignKey("Books")]
        public BookEntity Book { get; set; }
    }
}
