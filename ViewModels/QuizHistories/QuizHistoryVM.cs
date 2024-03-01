using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.QuizHistories
{
    public class QuizHistoryVM
    {
        [Key]
        public int QuizHistoryId { get; set; }
        public DateTime DateTaken { get; set; }
        public int Score { get; set; }
        public string Email { get; set; }
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public Account Account { get; set; }
        public List<QuestionHistory> QuestionHistories { get; set; }
    }
}
