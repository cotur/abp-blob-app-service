﻿using Volo.Abp.Content;

namespace Cotur.Abp.BlobManagement.Blob.Application.Services;

public interface ICrudBlobAppService<TContainer, TOutputStream, in TInputStream> : 
    IReadOnlyBlobAppService<TContainer, TOutputStream>,
    ICreateBlobAppService<TContainer, TInputStream>,
    IUpdateBlobAppService<TContainer, TInputStream>,
    IDeleteBlobAppService<TContainer>
    where TContainer : class
    where TOutputStream : IRemoteStreamContent, new()
    where TInputStream : IRemoteStreamContent, new()
{
    
}