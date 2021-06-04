using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Models.Entities
{
    public class BookEntity
    {
        public int Id { get; set; }
        [Required]
        public int AuthorEntityId { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual UsersBooks UserBook { get; set; }
    }
}
