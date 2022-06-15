using Betsson_Case.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Betsson_Case.Database
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                        .AddJsonFile("appsettings.json")
                                        .Build();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DataBaseConnectionString"));

        }
        public DbSet<CsvModel> CsvModel { get; set; }
    }
}
