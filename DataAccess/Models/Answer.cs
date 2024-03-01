using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        public string Description { get; set; } = string.Empty;

        public int QuestionId { get; set; }

        #region Relationships
        public virtual Question Question { get; set; }
        #endregion
    }
}
