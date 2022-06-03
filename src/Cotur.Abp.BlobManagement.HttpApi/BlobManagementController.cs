using Cotur.Abp.BlobManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Cotur.Abp.BlobManagement;

public abstract class BlobManagementController : AbpControllerBase
{
    protected BlobManagementController()
    {
        LocalizationResource = typeof(BlobManagementResource);
    }
}
