using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        public string SubjectName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }

        #region Relationship
        public virtual ICollection<Quiz>? Quizzes { get; set; }
        #endregion

    }
}
