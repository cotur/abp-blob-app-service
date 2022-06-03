using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Cotur.Abp.BlobManagement.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class BlobManagementBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "BlobManagement";
}
