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
        public int? QuizHistoryId { get; set; }
        public int? QuestionHistoryId { get; set; }
        public string? SelectedAnswer{ get; set; }
        public int QuestionId { get; set; }
    }
}
