using System.IO;
using System.Threading.Tasks;
using Volo.Abp.BlobStoring;
using Volo.Abp.Content;

namespace Cotur.Abp.Blob.Application
{
    public abstract class ReadOnlyBlobAppService<TContainer> :
        ReadOnlyBlobAppService<TContainer, IRemoteStreamContent>
        where TContainer : class
    {
        protected ReadOnlyBlobAppService(IBlobContainer<TContainer> blobContainer) : base(blobContainer)
        {
        }
    }

    public abstract class ReadOnlyBlobAppService<TContainer, TOutputStream> : 
        BlobApplicationService<TContainer>,
        IReadOnlyBlobAppService<TContainer, TOutputStream>
        where TContainer : class
        where TOutputStream : IRemoteStreamContent
    {
        protected virtual string GetPolicyName { get; set; }
    
        protected virtual string DefaultContentType { get; set; } = "application/octet-stream";
    
        protected ReadOnlyBlobAppService(IBlobContainer<TContainer> blobContainer) : base(blobContainer)
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


        public virtual async Task<TOutputStream> GetAsync(string id)
        {
            await CheckGetPolicyAsync();

            var blob = await GetBlobByNameAsync(id);

            return await CreateOutputStreamAsync(id, blob);
        }

        protected virtual async Task CheckGetPolicyAsync()
        {
            await CheckPolicyAsync(GetPolicyName);
        }
    }
}