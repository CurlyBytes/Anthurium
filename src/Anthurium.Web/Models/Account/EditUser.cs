using Anthurium.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.Web.Models.Account
{
    public class EditUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [MinLength(6, ErrorMessage = "The Password field must be a minimum of 6 characters")]
        public string Password { get; set; }

        public EditUser() { }

        public EditUser(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
        }
    }
}
