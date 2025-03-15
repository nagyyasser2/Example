using System.Security.Claims;
using Example.Api.Attributes;
using Example.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Example.Api.Filters
{
    public class PermissionBasedAuthorizationFilter(IUnitOfWork unitOfWork) : IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var attribute = context.ActionDescriptor.EndpointMetadata
                .OfType<CheckPermissionAttribute>()
                .FirstOrDefault();

            if (attribute == null)
            {
                return;
            }

            var claimIdentity = context.HttpContext.User.Identity as ClaimsIdentity;
            if (claimIdentity?.IsAuthenticated != true)
            {
                context.Result = new ForbidResult();
                return;
            }

            var userIdClaim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
            {
                context.Result = new ForbidResult();
                return;
            }

            var hasPermission = await unitOfWork.UserPermissions.AnyAsync(x =>
                x.UserId == userId && x.PermissionId == attribute.Permission);

            if (!hasPermission)
            {
                context.Result = new ForbidResult();
            }
        }
    }

}
