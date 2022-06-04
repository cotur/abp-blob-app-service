using System.Threading.Tasks;
using Volo.Abp.Content;

namespace Cotur.Abp.Blob.Application;

public interface ICreateBlobAppService<TContainer, in TInputStream> : 
    IBlobAppService<TContainer>
    where TContainer : class
    where TInputStream : IRemoteStreamContent, new()
{
    Task CreateAsync(string name, TInputStream inputStream);
}