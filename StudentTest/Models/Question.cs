using System.ComponentModel.DataAnnotations;

namespace StudentTest.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        [Required]
        public string QuestionText { get; set; }

        public string Explanation { get; set; }

        public ICollection<Answer> Answers { get; set; }

        public ICollection<TestSubmission> TestSubmissions { get; set; }

        
    }
}
