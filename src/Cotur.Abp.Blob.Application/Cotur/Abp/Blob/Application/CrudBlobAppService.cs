using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.BlobStoring;
using Volo.Abp.Content;

namespace Cotur.Abp.Blob.Application
{
    public abstract class CrudBlobAppService<TContainer> :
        CrudBlobAppService<TContainer, IRemoteStreamContent>
        where TContainer : class
    {
        protected CrudBlobAppService(IBlobContainer<TContainer> blobContainer) : base(blobContainer)
        {
        }
    }
        

    public abstract class CrudBlobAppService<TContainer, TOutputStream> :
        CrudBlobAppService<TContainer, TOutputStream, IRemoteStreamContent>
        where TContainer : class
        where TOutputStream : IRemoteStreamContent
    {
        protected CrudBlobAppService(IBlobContainer<TContainer> blobContainer) : base(blobContainer)
        {
        }
    }

    public abstract class CrudBlobAppService<TContainer, TOutputStream, TInputStream> : 
        ReadOnlyBlobAppService<TContainer, TOutputStream>,
        ICrudBlobAppService<TContainer, TOutputStream, TInputStream>
        where TContainer : class
        where TOutputStream : IRemoteStreamContent
        where TInputStream : IRemoteStreamContent
    {
        protected virtual string CreatePolicyName { get; set; }
        protected virtual string UpdatePolicyName { get; set; }
        protected virtual string DeletePolicyName { get; set; }
    
        protected CrudBlobAppService(IBlobContainer<TContainer> blobContainer) : base(blobContainer)
        {
        }
    
        public virtual async Task CreateAsync(string id, TInputStream inputStream)
        {
            await CheckCreatePolicyAsync();

            await BlobContainer.SaveAsync(id, inputStream.GetStream());
        }
        
        public virtual async Task UpdateAsync(string id, TInputStream inputStream)
        {
            await CheckUpdatePolicyAsync();

            if (!await BlobContainer.ExistsAsync(id))
            {
                // TODO: update exception
                throw new AbpException($"There is not such a BLOB with name: {id}");
            }
        
            await BlobContainer.SaveAsync(id, inputStream.GetStream(), overrideExisting: true);
        }
    
        public virtual async Task DeleteAsync(string id)
        {
            await CheckDeletePolicyAsync();
        
            await BlobContainer.DeleteAsync(id);
        }
    
        protected virtual async Task CheckCreatePolicyAsync()
        {
            await CheckPolicyAsync(CreatePolicyName);
        }
    
        protected virtual async Task CheckUpdatePolicyAsync()
        {
            await CheckPolicyAsync(UpdatePolicyName);
        }
    
        protected virtual async Task CheckDeletePolicyAsync()
        {
            await CheckPolicyAsync(DeletePolicyName);
        }
    }
}