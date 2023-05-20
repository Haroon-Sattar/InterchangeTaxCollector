using Application.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public static class IdentityResultExtensions
{
    public static ServiceResult ToApplicationResult(this IdentityResult result)
    {
        return result.Succeeded
            ? ServiceResult.Success<bool>(true)
            : ServiceResult.Failed(result.Errors.Select(e => e.Description), ServiceError.ForbiddenError);
    }
}
