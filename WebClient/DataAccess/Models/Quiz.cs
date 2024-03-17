using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Quiz
    {
        [Key]
        public int QuizId { get; set; }

        public string Title { get; set; } = string.Empty; 
        public string Description { get; set; } = string.Empty; 

        public int Duration { get; set; }

        public DateTime CreatedDate { get; set; }
        public int SubjectId { get; set; }
        #region Relationship
        public virtual Subject? Subject { get; set; }
        public virtual ICollection<Question>? Questions { get; set; }
        #endregion
    }
}
