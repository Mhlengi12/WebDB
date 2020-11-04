using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebDB.Models
{
    public partial class UserRegister
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required" )]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(20)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public string Confirm_Password { get; set; }
        public string Role { get; set; }
    }
}
