using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Cotur.Abp.BlobManagement.EntityFrameworkCore;

public class BlobManagementHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<BlobManagementHttpApiHostMigrationsDbContext>
{
    public BlobManagementHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<BlobManagementHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("BlobManagement"));

        return new BlobManagementHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
