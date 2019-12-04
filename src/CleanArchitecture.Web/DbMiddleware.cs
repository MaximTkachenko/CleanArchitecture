using System.Threading.Tasks;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.Web
{
    public class DbMiddleware
    {
        private readonly RequestDelegate _next;

        public DbMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, AppDbContext dbContext)
        {
            await _next(context);

            await dbContext.SaveChangesAsync();
        }
    }

    public static class DbMiddlewareExtensions
    {
        public static IApplicationBuilder UseDbMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DbMiddleware>();
        }
    }
}
