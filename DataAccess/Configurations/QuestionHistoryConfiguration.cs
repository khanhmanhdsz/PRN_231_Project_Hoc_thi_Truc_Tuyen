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
    public class QuestionHistoryConfiguration : IEntityTypeConfiguration<QuestionHistory>
    {
        public void Configure(EntityTypeBuilder<QuestionHistory> builder)
        {
            builder.ToTable(nameof(QuestionHistory));
            builder.HasKey(x => x.QuestionHistoryId);
            builder.Property(x => x.SelectedAnswerId).IsRequired();

            #region Relationship
            builder.HasOne(x => x.QuizHistory).WithMany(x => x.QuestionHistories).HasForeignKey(x => x.QuizHistoryId).OnDelete(DeleteBehavior.NoAction);
            #endregion
        }
    }
}
