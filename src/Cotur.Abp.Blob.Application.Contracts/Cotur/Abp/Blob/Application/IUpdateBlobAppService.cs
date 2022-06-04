using System.Threading.Tasks;
using Volo.Abp.Content;

namespace Cotur.Abp.Blob.Application;

public interface IUpdateBlobAppService<TContainer, in TInputStream> : 
    IBlobAppService<TContainer>
    where TContainer : class
    where TInputStream : IRemoteStreamContent, new()
{
    Task UpdateAsync(string name, TInputStream inputStream);
}