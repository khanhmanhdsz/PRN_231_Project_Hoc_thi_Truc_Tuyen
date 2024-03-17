using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Quizzes;

namespace ViewModels.Questions
{
    public class QuestionVM
    {
        public int? QuestionId { get; set; }

        [Required(ErrorMessage = "* Please enter question title")]
        [StringLength(300)]
        public string Title { get; set; } = string.Empty;
        public string CorrectAnswer { get; set; } = string.Empty;

        [Required(ErrorMessage = "* Please enter answer A")]
        [StringLength(500)]
        public string? AnswerA { get; set; } = string.Empty;
        [Required(ErrorMessage = "* Please enter answer B")]
        [StringLength(500)]
        public string? AnswerB { get; set; } = string.Empty;
        [Required(ErrorMessage = "* Please enter answer C")]
        [StringLength(500)]
        public string? AnswerC { get; set; } = string.Empty;
        [Required(ErrorMessage = "* Please enter answer D")]
        [StringLength(500)]
        public string? AnswerD { get; set; } = string.Empty;
        public int? QuizId { get; set; }
        public QuizVM? Quiz { get; set; }
    }
}
