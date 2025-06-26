

public static class CustomMapExtention
{
    public static IApplicationBuilder CustomMap(this IApplicationBuilder app, string path)
    {
        app.Map(path, app=>
        {
            app.Run(async context=>
            {
                await context.Response.WriteAsync("Custom Middleware");
            });
        });
        return app;
    }
}