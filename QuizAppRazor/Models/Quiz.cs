using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuizAppRazor.Models
{
    public class Quiz
    {
        [Key]
        [DisplayName("Id")]
      
        public int quiz_id { get; set; }
        [Required]
        [MaxLength(15)]
        [DisplayName("Topic Name")]
        public string Topic { get; set; }
    }
}
