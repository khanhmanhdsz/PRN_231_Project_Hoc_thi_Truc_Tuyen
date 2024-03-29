﻿namespace DataAccess.Models
{
    public class QuestionHistory
    {
        public int QuestionHistoryId { get; set; }
        public string SelectedOption { get; set; }
        public int QuestionId { get; set; }
        public int QuizHistoryId { get; set; }
        public bool IsCorrect { get; set; }
        #region Relationship 
        public virtual QuizHistory? QuizHistory { get; set; }
        public virtual Question? Question { get; set; }
        #endregion

    }
}
