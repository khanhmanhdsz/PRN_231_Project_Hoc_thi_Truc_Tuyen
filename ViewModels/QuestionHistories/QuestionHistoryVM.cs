using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ViewModels.Questions;

namespace ViewModels.QuestionHistories
{
    public class QuestionHistoryVM
    {
        public int? QuizHistoryId { get; set; }
        public int? QuestionHistoryId { get; set; }

        [JsonPropertyName("selectedOption")]
        public string? SelectedOption { get; set; }

        [JsonPropertyName("questionId")]
        public int? QuestionId { get; set; }
        public QuestionVM? QuestionVM { get; set; }
        public bool? IsCorrect { get; set; } 
    }
}
