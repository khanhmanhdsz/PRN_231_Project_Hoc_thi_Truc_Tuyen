using DataAccess.Configurations;
using DataAccess.Models;
using DataAccess.Seeding;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.FcmsContext
{
    public class OnlineExamDbContext : IdentityDbContext<Account, IdentityRole<Guid>, Guid>
    {
        public OnlineExamDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Get connection strings in appsetings.json
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfigurationRoot configuration = builder.Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DB"));
            }
        }
        /// <summary>
        /// Apply db configuration
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new QuizConfiguration());
            modelBuilder.ApplyConfiguration(new QuizHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());

            new AccountSeeder(modelBuilder).Seed();

            base.OnModelCreating(modelBuilder);
        }

        #region DbSet
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuizHistory> QuizHistories { get; set; }
        public DbSet<QuestionHistory> QuestionHistories { get; set; }
 
        #endregion
    }
}