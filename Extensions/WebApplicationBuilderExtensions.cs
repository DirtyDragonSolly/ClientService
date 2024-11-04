using ClientService.Data;
using ClientService.Services.Implementations;
using ClientService.Services.Interfaces;
using ClientServise.Services.Implementations;
using ClientServise.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;

namespace ClientService.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder ConfigureDIContainer(this WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Logging.ClearProviders();
            applicationBuilder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

            applicationBuilder.Services.AddControllers();

            applicationBuilder.AddSwaggerConfiguration();
            applicationBuilder.AddDbContext();
            applicationBuilder.AddLogic();

            return applicationBuilder;
        }

        private static WebApplicationBuilder AddLogic(this WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddScoped<IClientManager, ClientManager>();
            applicationBuilder.Services.AddScoped<IFounderManager, FounderManager>();

            return applicationBuilder;
        }

        private static WebApplicationBuilder AddDbContext(this WebApplicationBuilder applicationBuilder)
        {
            var connectionString = applicationBuilder.Configuration.GetConnectionString("DefaultConnection");

            applicationBuilder.Services.AddDbContext<ClientContext>((options) => options.UseNpgsql(connectionString));

            return applicationBuilder;
        }

        private static WebApplicationBuilder AddSwaggerConfiguration(this WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Client.Service.Api"
                });
            });

            return applicationBuilder;
        }
    }
}
