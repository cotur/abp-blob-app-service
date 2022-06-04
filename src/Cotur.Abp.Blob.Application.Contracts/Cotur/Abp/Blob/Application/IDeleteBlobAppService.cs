using System.Threading.Tasks;

namespace Cotur.Abp.Blob.Application;

public interface IDeleteBlobAppService<TContainer> : 
    IBlobAppService<TContainer>
    where TContainer : class
{
    Task DeleteAsync(string name);
}