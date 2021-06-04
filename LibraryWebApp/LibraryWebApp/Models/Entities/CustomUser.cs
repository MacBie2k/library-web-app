using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Models.Entities
{
    public class CustomUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public virtual AdressEntity Adress { get; set; }
        public virtual IEnumerable<UsersBooks> UserBook { get; set; }
    }
}
