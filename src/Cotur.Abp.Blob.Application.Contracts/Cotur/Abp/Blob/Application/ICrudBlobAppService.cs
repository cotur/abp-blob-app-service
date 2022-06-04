using Volo.Abp.Content;

namespace Cotur.Abp.Blob.Application;

public interface ICrudBlobAppService<TContainer> :
    ICrudBlobAppService<TContainer, IRemoteStreamContent>
    where TContainer : class
{
    
}

public interface ICrudBlobAppService<TContainer, TOutputStream> :
    ICrudBlobAppService<TContainer, TOutputStream, IRemoteStreamContent>
    where TContainer : class
    where TOutputStream : IRemoteStreamContent
{
    
}

public interface ICrudBlobAppService<TContainer, TOutputStream, in TInputStream> : 
    IReadOnlyBlobAppService<TContainer, TOutputStream>,
    ICreateBlobAppService<TContainer, TInputStream>,
    IUpdateBlobAppService<TContainer, TInputStream>,
    IDeleteBlobAppService<TContainer>
    where TContainer : class
    where TOutputStream : IRemoteStreamContent
    where TInputStream : IRemoteStreamContent
{
    
}