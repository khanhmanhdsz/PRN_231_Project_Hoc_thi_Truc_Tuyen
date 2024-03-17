using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.ToTable(nameof(Quiz));
            builder.HasKey(x => x.QuizId);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Duration).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();

            #region Relationship
            builder.HasOne(x => x.Subject).WithMany(x => x.Quizzes).HasForeignKey(x => x.SubjectId).OnDelete(DeleteBehavior.NoAction);
            #endregion
        }
    }
}
