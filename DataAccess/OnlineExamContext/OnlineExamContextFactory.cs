using DataAccess.FcmsContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace DataAccess.OnlineExamContext
{
    public class OnlineExamContextFactory : IDesignTimeDbContextFactory<OnlineExamDbContext>
    {
        public OnlineExamDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DB");
            var optionBuilder = new DbContextOptionsBuilder<OnlineExamDbContext>();
            optionBuilder.UseSqlServer(connectionString);

            return new OnlineExamDbContext(optionBuilder.Options);
        }
    }
}
