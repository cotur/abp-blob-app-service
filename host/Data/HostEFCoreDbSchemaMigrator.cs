using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace Cotur.Abp.Blob.Host.Data;

public class HostEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public HostEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the HostDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<HostDbContext>()
            .Database
            .MigrateAsync();
    }
}
