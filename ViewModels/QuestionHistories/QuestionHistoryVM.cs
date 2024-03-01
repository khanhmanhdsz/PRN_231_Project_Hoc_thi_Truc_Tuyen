using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.QuestionHistories
{
    public class QuestionHistoryVM
    {
        public int QuestionHistoryId { get; set; }
        public int SelectedAnswerId { get; set; }
        public int QuestionId { get; set; }
        public int QuizHistoryId { get; set; }
        public QuizHistory QuizHistory { get; set; }
        public Question Question { get; set; }
    }
}
