using Microsoft.AspNetCore.Mvc.Filters;

namespace Example.Api.Filters
{
    public class PermissionBasedAuthorizationFilter: IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            throw new NotImplementedException();
        }
    }
}
