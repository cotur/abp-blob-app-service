using System.Threading.Tasks;
using Volo.Abp.Content;

namespace Cotur.Abp.Blob.Application;

public interface ICreateBlobAppService<TContainer> :
    ICreateBlobAppService<TContainer, IRemoteStreamContent>
    where TContainer : class
{
    
}

public interface ICreateBlobAppService<TContainer, in TInputStream> : 
    IBlobAppService<TContainer>
    where TContainer : class
    where TInputStream : IRemoteStreamContent
{
    Task CreateAsync(string id, TInputStream inputStream);
}