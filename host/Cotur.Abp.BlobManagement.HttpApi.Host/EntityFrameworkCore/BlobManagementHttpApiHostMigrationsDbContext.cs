using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Cotur.Abp.BlobManagement.EntityFrameworkCore;

public class BlobManagementHttpApiHostMigrationsDbContext : AbpDbContext<BlobManagementHttpApiHostMigrationsDbContext>
{
    public BlobManagementHttpApiHostMigrationsDbContext(DbContextOptions<BlobManagementHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureBlobManagement();
    }
}
