using Cotur.Abp.BlobManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Cotur.Abp.BlobManagement.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class BlobManagementPageModel : AbpPageModel
{
    protected BlobManagementPageModel()
    {
        LocalizationResourceType = typeof(BlobManagementResource);
        ObjectMapperContext = typeof(BlobManagementWebModule);
    }
}
