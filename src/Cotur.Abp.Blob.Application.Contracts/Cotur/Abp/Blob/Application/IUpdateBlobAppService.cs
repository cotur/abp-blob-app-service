using System.Threading.Tasks;
using Volo.Abp.Content;

namespace Cotur.Abp.Blob.Application;

public interface IUpdateBlobAppService<TContainer> :
    IUpdateBlobAppService<TContainer, IRemoteStreamContent>
    where TContainer : class
{
    
}


public interface IUpdateBlobAppService<TContainer, in TInputStream> : 
    IBlobAppService<TContainer>
    where TContainer : class
    where TInputStream : IRemoteStreamContent
{
    Task UpdateAsync(string id, TInputStream inputStream);
}