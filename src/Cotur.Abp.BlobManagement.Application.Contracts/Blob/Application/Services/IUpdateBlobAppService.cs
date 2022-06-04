using System.Threading.Tasks;
using Volo.Abp.Content;

namespace Cotur.Abp.BlobManagement.Blob.Application.Services;

public interface IUpdateBlobAppService<TContainer, in TInputStream> : 
    IBlobAppService<TContainer>
    where TContainer : class
    where TInputStream : IRemoteStreamContent, new()
{
    Task UpdateAsync(string name, TInputStream inputStream);
}