using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string CorrectAnswer { get; set; } = string.Empty;
        public string AnswerA { get; set; } = string.Empty;
        public string AnswerB { get; set; } = string.Empty;
        public string AnswerC { get; set; } = string.Empty;
        public string AnswerD { get; set; } = string.Empty;
        public int QuizId { get; set; }

        #region Relationship
        public virtual Quiz? Quiz { get; set; }
        #endregion
    }
}
