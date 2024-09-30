using System.ComponentModel.DataAnnotations;

namespace StudentTest.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        public UserLogin UserLogin { get; set; } // Navigation property to UserLogin
    }

}
