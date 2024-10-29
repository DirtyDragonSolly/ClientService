using Swashbuckle.AspNetCore.SwaggerUI;

namespace ClientService.Extensions
{
    public static class WebApplicationExtensions
    {
        public static WebApplication ConfigureMiddlewares(this WebApplication webApplication)
        {
            webApplication.UseRouting();
            webApplication.MapControllers();

            if (!webApplication.Environment.IsProduction())
            {
                webApplication.UseSwagger();
                webApplication.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Client Service API");
                    c.RoutePrefix = string.Empty;
                    c.DocExpansion(DocExpansion.None);
                    c.DisplayRequestDuration();
                });
            }

            return webApplication;
        }
    }
}
