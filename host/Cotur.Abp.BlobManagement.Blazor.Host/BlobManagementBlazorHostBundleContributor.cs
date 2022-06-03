using Volo.Abp.Bundling;

namespace Cotur.Abp.BlobManagement.Blazor.Host;

public class BlobManagementBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
