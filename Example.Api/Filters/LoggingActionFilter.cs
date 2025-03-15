using Microsoft.AspNetCore.Mvc.Filters;

namespace Example.Api.Filters
{
    public class LoggingActionFilter(ILogger<LoggingActionFilter> logger) : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            logger.LogInformation($"Executing action: {context.ActionDescriptor.DisplayName}");

            var resultContext = await next();

            logger.LogInformation($"Executed action: {context.ActionDescriptor.DisplayName}");
        }
    }
}
