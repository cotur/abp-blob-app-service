using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Cotur.Abp.Blob.Host;

[Dependency(ReplaceServices = true)]
public class HostBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Host";
}
