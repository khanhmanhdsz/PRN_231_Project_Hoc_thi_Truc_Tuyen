using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable(nameof(Question));
            builder.HasKey(x => x.QuestionId);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(5000);
            builder.Property(x => x.AnswerA).IsRequired().HasMaxLength(5000);
            builder.Property(x => x.AnswerB).IsRequired().HasMaxLength(5000);
            builder.Property(x => x.AnswerC).IsRequired().HasMaxLength(5000);
            builder.Property(x => x.AnswerD).IsRequired().HasMaxLength(5000);
            builder.Property(x => x.CorrectAnswer).IsRequired();

            #region Relationship
            builder.HasOne(x => x.Quiz).WithMany(x => x.Questions).HasForeignKey(x => x.QuizId).OnDelete(DeleteBehavior.NoAction);

            #endregion
        }
    }
}
