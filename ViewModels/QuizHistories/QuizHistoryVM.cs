using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Accounts;
using ViewModels.Quizzes;
using ViewModels.QuestionHistories;

namespace ViewModels.QuizHistories
{
    public class QuizHistoryVM
    {
        public int? QuizHistoryId { get; set; }
        public int? QuizId { get; set; }
        public DateTime? DateTaken { get; set; }
        public int? Score { get; set; }
        public Guid? Id { get; set; }
        public QuizVM? Quiz { get; set; }
        public AccountVM? Account { get; set; }
        public List<QuestionHistoryVM>? QuestionHistories { get; set; }
    }
}
