using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Cotur.Abp.BlobManagement;

[Dependency(ReplaceServices = true)]
public class BlobManagementBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "BlobManagement";
}
