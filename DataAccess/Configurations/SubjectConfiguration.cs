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
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable(nameof(Subject));
            builder.HasKey(x => x.SubjectId);
            builder.Property(x => x.SubjectName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);

            #region Relationships

            #endregion
        }
    }
}
