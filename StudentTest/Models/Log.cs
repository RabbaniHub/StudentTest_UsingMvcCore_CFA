using System.ComponentModel.DataAnnotations;

namespace StudentTest.Models
{
    public class Log
    {
        [Key]
        public int LogId { get; set; }

        public string Action { get; set; } // e.g., "Login", "Submit Test"

        public DateTime TimeStamp { get; set; }

        public string Details { get; set; } // Store additional information like user ID, etc.
    }

}
