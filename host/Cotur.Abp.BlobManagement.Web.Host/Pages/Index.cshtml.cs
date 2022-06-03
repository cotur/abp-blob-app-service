using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Cotur.Abp.BlobManagement.Pages;

public class IndexModel : BlobManagementPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
