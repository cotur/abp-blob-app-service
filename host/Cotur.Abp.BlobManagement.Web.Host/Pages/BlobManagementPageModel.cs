using Cotur.Abp.BlobManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Cotur.Abp.BlobManagement.Pages;

public abstract class BlobManagementPageModel : AbpPageModel
{
    protected BlobManagementPageModel()
    {
        LocalizationResourceType = typeof(BlobManagementResource);
    }
}
