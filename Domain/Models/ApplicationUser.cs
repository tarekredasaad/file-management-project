using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Domain.Models
{


    public class ApplicationUser
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = " Name is required")]

        public string Name { get; set; }
        //[Index(IsUnique = true)]
        [Required(ErrorMessage = " Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = " Password is required")]

        public string Password { get; set; }

        public string? Address { get; set; }
        //public DateTime LastLoginTime { get; set; }
    }
}
