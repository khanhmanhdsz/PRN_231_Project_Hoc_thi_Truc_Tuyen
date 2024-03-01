using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Questions
{
    public class QuestionVM
    {
        [Key]
        public int QuestionId { get; set; }

        [Required(ErrorMessage = "* Please enter question title")]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "* Please enter quesiton description")]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
        public int QuizId { get; set; }
        public int CorrectAnswerId { get; set; }
        public  Quiz Quiz { get; set; }
        public  List<Answer> Answers { get; set; }
    }
}
