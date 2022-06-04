using System.Threading.Tasks;
using Volo.Abp.Content;

namespace Cotur.Abp.BlobManagement.Blob.Application.Services;

public interface ICreateBlobAppService<TContainer, in TInputStream> : 
    IBlobAppService<TContainer>
    where TContainer : class
    where TInputStream : IRemoteStreamContent, new()
{
    Task CreateAsync(string name, TInputStream inputStream);
}