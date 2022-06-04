using System.IO;
using System.Threading.Tasks;
using Cotur.Abp.BlobManagement.Blob.Application.Services;
using Volo.Abp.BlobStoring;
using Volo.Abp.Content;

namespace Cotur.Abp.BlobManagement.Blob.Application;

public abstract class BlobReadOnlyAppService<TContainer, TOutputStream> : 
    BlobApplicationService<TContainer>,
    IReadOnlyBlobAppService<TContainer, TOutputStream>
    where TContainer : class
    where TOutputStream : IRemoteStreamContent, new()
{
    protected virtual string GetPolicyName { get; set; }
    
    protected virtual string DefaultContentType { get; set; } = "application/octet-stream";
    
    protected BlobReadOnlyAppService(IBlobContainer<TContainer> blobContainer) : base(blobContainer)
    {
    }
    
    protected virtual Task<Stream> GetBlobByNameAsync(string name)
    {
        return BlobContainer.GetAsync(name);
    }
    
    protected virtual Task<TOutputStream> CreateOutputStreamAsync(string name, Stream blobStream)
    {
        var streamContent = new RemoteStreamContent(blobStream, name, DefaultContentType, blobStream.Length);

        return Task.FromResult((TOutputStream) ((IRemoteStreamContent) streamContent));
    }


    public virtual async Task<TOutputStream> GetAsync(string name)
    {
        await CheckGetPolicyAsync();

        var blob = await GetBlobByNameAsync(name);

        return await CreateOutputStreamAsync(name, blob);
    }

    protected virtual async Task CheckGetPolicyAsync()
    {
        await CheckPolicyAsync(GetPolicyName);
    }
}