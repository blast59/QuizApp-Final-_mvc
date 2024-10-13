using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models
{
    public class Submission
    {
        [Key]
        public int Submission_Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int Quiz_Id { get; set; }
        [Required]
        public string Score { get; set; }
        [Required]
        public DateTime SubmittedAt { get; set;}
            
    }
}
