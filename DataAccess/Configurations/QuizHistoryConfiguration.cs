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
    public class QuizHistoryConfiguration : IEntityTypeConfiguration<QuizHistory>
    {
        public void Configure(EntityTypeBuilder<QuizHistory> builder)
        {
            builder.ToTable(nameof(QuizHistory));
            builder.HasKey(x => x.QuizHistoryId);
            builder.Property(x => x.DateTaken).IsRequired();
            builder.Property(x => x.Score).IsRequired();

            #region Relationship
            builder.HasOne(x => x.Account).WithMany(x => x.QuizHistories).HasForeignKey(x => x.Id).OnDelete(DeleteBehavior.NoAction);

            #endregion
        }
    }
}
