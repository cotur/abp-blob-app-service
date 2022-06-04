# ABP Blob App Service

This module provides some abstract base classes to create interaction with client and your Blob Storages.

## Pre Requirements

-   BLOB Storaging System (see: [docs](https://docs.abp.io/en/abp/latest/Blob-Storing))

## How to Install

This module's projects are not published yet as NuGet packages, so for now, you need to download the module via GitHub and add references each project to related application project.

1. Download the module source code
2. Add project references one by one as following:
    - `*.Application.Contacts` -> `Cotur.Abp.Blob.Application.Contacts`
    - `*.Application` -> `Cotur.Abp.Blob.Application`

## Usage

1. Example [ProfilePictureAppService.cs](https://github.com/cotur/abp-blob-app-service/blob/2283c2c9d014fa1efc007041000892ac3a282682/host/Services/ProfilePictureAppService.cs)
2. Example [VideoAppService.cs](https://github.com/cotur/abp-blob-app-service/blob/2283c2c9d014fa1efc007041000892ac3a282682/host/Services/VideoAppService.cs)

## Roadmap

- [ ] Extended input validation
- [ ] Extended output manipulation
