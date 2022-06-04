using Cotur.Abp.Blob.Application;
using Cotur.Abp.Blob.Host.BlobContainers;
using Volo.Abp.BlobStoring;

namespace Cotur.Abp.Blob.Host.Services;

public class VideoAppService : CrudBlobAppService<VideoContainer>
{
    public VideoAppService(IBlobContainer<VideoContainer> blobContainer) : base(blobContainer)
    {
        DefaultContentType = "video/mp4";
    }
}