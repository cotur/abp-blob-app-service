using Cotur.Abp.BlobManagement.Localization;
using Volo.Abp.Application.Services;

namespace Cotur.Abp.BlobManagement;

public abstract class BlobManagementAppService : ApplicationService
{
    protected BlobManagementAppService()
    {
        LocalizationResource = typeof(BlobManagementResource);
        ObjectMapperContext = typeof(BlobManagementApplicationModule);
    }
}
