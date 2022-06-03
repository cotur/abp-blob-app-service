using Volo.Abp.Reflection;

namespace Cotur.Abp.BlobManagement.Permissions;

public class BlobManagementPermissions
{
    public const string GroupName = "BlobManagement";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(BlobManagementPermissions));
    }
}
