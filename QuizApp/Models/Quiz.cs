using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Models
{
    public class Quiz
    {
        [Key]
        [DisplayName("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  quiz_id { get; set; }
        [Required]
        [MaxLength(15)]
        [DisplayName("Topic Name")]
        public string Topic { get; set; }
    }
}
