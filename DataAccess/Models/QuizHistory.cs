using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class QuizHistory
    {
        [Key]
        public int QuizHistoryId { get; set; }
        public DateTime DateTaken { get; set; }
        public int Score { get; set; }
        public Guid Id { get; set; }
        public int QuizId { get; set; }
        #region Relationship
        public virtual Quiz Quiz { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<QuestionHistory> QuestionHistories { get; set; }
        #endregion
    }
}
