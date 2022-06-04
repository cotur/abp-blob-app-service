using Cotur.Abp.BlobManagement.Blob.Application.Services;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;

namespace Cotur.Abp.BlobManagement.Blob.Application;

public abstract class BlobApplicationService<TContainer> : 
    ApplicationService,
    IBlobAppService<TContainer> where TContainer : class
{
    protected IBlobContainer<TContainer> BlobContainer { get; }

    protected BlobApplicationService(IBlobContainer<TContainer> blobContainer)
    {
        BlobContainer = blobContainer;
    }
}