using Microsoft.AspNetCore.Identity;

namespace DataAccess.Models
{
    public class Account : IdentityUser<Guid>
    {
        public string Fullname { get; set; } = string.Empty;
        public DateTime JoinedDate { get; set;}
        public bool IsAccountActive { get; set; }

        #region Relationship
        public virtual ICollection<QuizHistory>? QuizHistories { get; set; }
        #endregion
    }
}
