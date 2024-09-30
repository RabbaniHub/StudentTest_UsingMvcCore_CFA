using System.ComponentModel.DataAnnotations;

namespace StudentTest.Models
{
    public class UserLogin
    {
        [Key]
        public int UserLoginId { get; set; }

        [Required]
        public int UserId { get; set; } // Foreign key to User table

        [Required]
        public DateTime LoginTime { get; set; }

        [Required]
        public bool IsLoggedIn { get; set; }

        public User User { get; set; } // Navigation property
    }

}
