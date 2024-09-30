using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTest.Models
{
    public class TestSubmission
    {
        
        public int QuestionId { get; set; }

        [Key]
        public int SelectedAnswerId { get; set; }

        
    }
}
