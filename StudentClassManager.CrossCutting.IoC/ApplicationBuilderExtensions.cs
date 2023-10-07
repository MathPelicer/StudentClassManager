using Microsoft.AspNetCore.Builder;
using StudentClassManager.Application.Middlewares;

namespace StudentClassManager.CrossCutting.IoC
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddGlobalErrorHandler(this IApplicationBuilder applicationBuilder)
            => applicationBuilder.UseMiddleware<GlobalErrorHandlingMiddleware>();
    }
}
