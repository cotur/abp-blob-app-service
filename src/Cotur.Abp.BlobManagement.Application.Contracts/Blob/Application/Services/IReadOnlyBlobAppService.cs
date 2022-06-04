using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace Cotur.Abp.BlobManagement.Blob.Application.Services;

public interface IBlobAppService<TContainer> : IApplicationService where TContainer : class 
{
    
}

public interface IReadOnlyBlobAppService<TContainer, TOutputStream> : 
    IBlobAppService<TContainer> 
    where TContainer : class
    where TOutputStream : IRemoteStreamContent, new()
{
    Task<TOutputStream> GetAsync(string name);
}