using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace Cotur.Abp.Blob.Application;

public interface IBlobAppService<TContainer> : IApplicationService where TContainer : class 
{
    
}

public interface IReadOnlyBlobAppService<TContainer> :
    IReadOnlyBlobAppService<TContainer, IRemoteStreamContent>
    where TContainer : class
{
    
}

public interface IReadOnlyBlobAppService<TContainer, TOutputStream> : 
    IBlobAppService<TContainer> 
    where TContainer : class
    where TOutputStream : IRemoteStreamContent
{
    Task<TOutputStream> GetAsync(string id);
}