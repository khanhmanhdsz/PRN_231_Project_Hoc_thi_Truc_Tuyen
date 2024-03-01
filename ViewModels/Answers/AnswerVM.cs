using DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Answers
{
    public class AnswerVM
    {
        [Key]
        public int AnswerId { get; set; }

        [Required(ErrorMessage = "* Please enter answer content")]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        public int QuestionId { get; set; }

        public Question Question { get; set; }
    }
}
