using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.BlobStoring;
using Volo.Abp.Content;

namespace Cotur.Abp.Blob.Application
{
    public abstract class BlobCrudAppService<TContainer, TOutputStream, TInputStream> : 
        BlobReadOnlyAppService<TContainer, TOutputStream>,
        ICrudBlobAppService<TContainer, TOutputStream, TInputStream>
        where TContainer : class
        where TOutputStream : IRemoteStreamContent, new()
        where TInputStream : IRemoteStreamContent, new()
    {
        protected virtual string CreatePolicyName { get; set; }
        protected virtual string UpdatePolicyName { get; set; }
        protected virtual string DeletePolicyName { get; set; }
    
        protected BlobCrudAppService(IBlobContainer<TContainer> blobContainer) : base(blobContainer)
        {
        }
    
        public virtual async Task CreateAsync(string name, TInputStream inputStream)
        {
            await CheckCreatePolicyAsync();

            await BlobContainer.SaveAsync(name, inputStream.GetStream());
        }
        
        public virtual async Task UpdateAsync(string name, TInputStream inputStream)
        {
            await CheckUpdatePolicyAsync();

            if (!await BlobContainer.ExistsAsync(name))
            {
                // TODO: update exception
                throw new AbpException($"There is not such a BLOB with name: {name}");
            }
        
            await BlobContainer.SaveAsync(name, inputStream.GetStream(), overrideExisting: true);
        }
    
        public virtual async Task DeleteAsync(string name)
        {
            await CheckDeletePolicyAsync();
        
            await BlobContainer.DeleteAsync(name);
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