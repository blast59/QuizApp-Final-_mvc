using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IdentityUser = Microsoft.AspNetCore.Identity.IdentityUser;

namespace QuizApp.Models
{
    public class Submission
    {
        [Key]
        public int Submission_Id { get; set; }
        [Required]

        public string Topic { get; set; }
        [ForeignKey("Topic")]
        
        public string? UserName { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual IdentityUser User { get; set; } // Assuming you're using IdentityUser


        public int Quiz_Id { get; set; }
        [ForeignKey("Quiz_Id")]
        public Quiz? Quiz { get; set; }

        [Required]
        public string Score { get; set; }
        [DataType(DataType.DateTime)] // Optional, helps with validation
        public DateTime SubmittedAt { get; set; } = DateTime.Now; // Default value in C#

        public string Result { get; set; }

    }
}
