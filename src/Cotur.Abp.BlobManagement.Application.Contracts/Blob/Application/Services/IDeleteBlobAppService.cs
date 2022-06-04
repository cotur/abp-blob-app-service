using System.Threading.Tasks;

namespace Cotur.Abp.BlobManagement.Blob.Application.Services;

public interface IDeleteBlobAppService<TContainer> : 
    IBlobAppService<TContainer>
    where TContainer : class
{
    Task DeleteAsync(string name);
}