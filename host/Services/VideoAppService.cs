using Cotur.Abp.Blob.Application;
using Cotur.Abp.Blob.Host.BlobContainers;
using Volo.Abp.BlobStoring;
using Volo.Abp.Content;

namespace Cotur.Abp.Blob.Host.Services;

public class VideoAppService : CrudBlobAppService<VideoContainer>
{
    public VideoAppService(IBlobContainer<VideoContainer> blobContainer) : base(blobContainer)
    {
        DefaultContentType = "video/mp4";
    }
    
    protected override Task<IRemoteStreamContent> CreateOutputStreamAsync(string name, Stream blobStream)
    {
        var streamContent = new RemoteStreamContent(blobStream, null, DefaultContentType, blobStream.Length);

        return Task.FromResult((IRemoteStreamContent) streamContent);
    }
}