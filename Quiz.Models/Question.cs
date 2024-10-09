using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Quiz.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        public int QuizId { get; set; }
        [Required]
        public string QuestionText { get; set; }
        [Required]
        public string OptionA { get; set; }
        [Required]
        public string OptionB { get; set; }
        [Required]
        public string OptionC { get; set; }
        [Required]
        public string OptionD { get; set; }
        [Required]
        public string CorrectOption { get; set; }
        [Required]
        public int TimeLimitInSeconds { get; set; }
        [Required]
        public string Difficulty { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public int CreatedAt { get; set; }
    }
}
