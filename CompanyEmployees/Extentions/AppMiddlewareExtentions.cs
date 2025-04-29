using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace CompanyEmployees.Extentions
{
    public static class AppMiddlewareExtentions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var feature = context.Features.Get<IExceptionHandlerFeature>();
                    if (feature != null)
                    {
                        context.Response.StatusCode = feature.Error switch
                        {
                            EntityNotFoundException => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError
                        };
                        await context.Response.WriteAsync(context.Response.StatusCode + ", " + feature.Error.Message);
                    }
                });
            });

            return app;
        }
    }
}
