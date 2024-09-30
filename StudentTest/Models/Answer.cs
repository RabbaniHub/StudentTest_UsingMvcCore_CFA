using System.ComponentModel.DataAnnotations;

namespace StudentTest.Models
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }

        [Required]
        public string AnswerText { get; set; }

        public bool IsCorrect { get; set; }

        // Foreign key to associate this answer with a question
        public int QuestionId { get; set; }

        // Navigation property
        public Question Question { get; set; } // Each answer belongs to a question

    }
}
