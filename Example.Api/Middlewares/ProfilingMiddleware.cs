using System.Diagnostics;

namespace Example.Api.Middlewares
{
    public class ProfilingMiddleware(RequestDelegate next, ILogger<ProfilingMiddleware> logger)
    {
        public async Task Invoke(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            try
            {
                await next(context);
            }
            finally
            {
                stopwatch.Stop();

                var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
                logger.LogInformation("Request for {Path} took {ElapsedMilliseconds}ms", context.Request.Path, elapsedMilliseconds);
            }
        }
    }
}
