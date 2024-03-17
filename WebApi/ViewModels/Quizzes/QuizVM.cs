using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Questions;
using ViewModels.Subjects;

namespace ViewModels.Quizzes
{
    public class QuizVM
    {
        public int? QuizId { get; set; }

        [Required(ErrorMessage = "* Please enter quiz title")]
        [StringLength(100)]
        public string? Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "* Please enter quiz description")]
        [StringLength(100)]
        public string? Description { get; set; } = string.Empty;

        public int? Duration { get; set; }

        public DateTime? CreatedDate { get; set; }
        public int? SubjectId { get; set; }
        public SubjectVM? Subject { get; set; }
        public List<QuestionVM>? Questions { get; set; }
    }
}
