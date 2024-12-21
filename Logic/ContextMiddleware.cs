using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AmentumExploratory.Logic
{
    public class ContextMiddleware
    {
        private readonly RequestDelegate _next;

        public ContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext, ContextService contextService)
        {

           contextService.Register(httpContext.Request.Path, httpContext.Connection.RemoteIpAddress?.ToString() ?? "", DateTime.Now);        

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ContextMiddlewareExtensions
    {
        public static IApplicationBuilder UseContextMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ContextMiddleware>();
        }
    }
}
