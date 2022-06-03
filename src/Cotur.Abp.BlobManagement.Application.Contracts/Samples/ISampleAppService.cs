using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Cotur.Abp.BlobManagement.Samples;

public interface ISampleAppService : IApplicationService
{
    Task<SampleDto> GetAsync();

    Task<SampleDto> GetAuthorizedAsync();
}
