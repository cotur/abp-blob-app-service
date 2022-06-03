using Cotur.Abp.BlobManagement.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Cotur.Abp.BlobManagement.Blazor.Server.Host;

public abstract class BlobManagementComponentBase : AbpComponentBase
{
    protected BlobManagementComponentBase()
    {
        LocalizationResource = typeof(BlobManagementResource);
    }
}
