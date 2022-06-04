using Cotur.Abp.Blob.Application;
using Cotur.Abp.Blob.Host.BlobContainers;
using Volo.Abp.BlobStoring;
using Volo.Abp.Content;

namespace Cotur.Abp.Blob.Host.Services;

public class ProfilePictureAppService : CrudBlobAppService<ProfilePictureContainer>
{
    public ProfilePictureAppService(IBlobContainer<ProfilePictureContainer> blobContainer) : base(blobContainer)
    {
        DefaultContentType = "image/jpeg";
    }

    protected override Task<IRemoteStreamContent> CreateOutputStreamAsync(string name, Stream blobStream)
    {
        // if you do not set the fileName, explorers will try to download the blob instead of displaying them.
        // See: https://github.com/abpframework/abp/blob/a2d0169e9b7defa812c633944cab25686056c780/framework/src/Volo.Abp.AspNetCore.Mvc/Volo/Abp/AspNetCore/Mvc/ContentFormatters/RemoteStreamContentOutputFormatter.cs#L32
        // See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Disposition#syntax
        var streamContent = new RemoteStreamContent(blobStream, null, DefaultContentType, blobStream.Length);

        return Task.FromResult((IRemoteStreamContent) streamContent);
    }
}