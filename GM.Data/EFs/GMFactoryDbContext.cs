using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace GM.Data.EFs
{
    internal class GMFactoryDbContext : IDesignTimeDbContextFactory<GMDbContext>
    {
        public GMDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();

            var connectionString = configurationRoot.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<GMDbContext>();

            optionsBuilder.UseSqlServer(connectionString);
            return new GMDbContext(optionsBuilder.Options);
        }
    }
}
