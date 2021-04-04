namespace Identity.Api
{
    using System.Text.Json.Serialization;
    using AlbedoTeam.Sdk.Documentation;
    using AlbedoTeam.Sdk.Documentation.Models;
    using AlbedoTeam.Sdk.ExceptionHandler;
    using AlbedoTeam.Sdk.FailFast;
    using AlbedoTeam.Sdk.Validations;
    using Mappers;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDocumentation(apiDocument =>
            {
                apiDocument.Title = "Identity Domain API";
                apiDocument.Description = "codiname: Pandora's Actor :)";
                apiDocument.Contact = new ApiContact
                {
                    Name = "Albedo Team",
                    Email = "contato@albedo.team",
                    Url = "https://albedo.team"
                };

                apiDocument
                    .AddVersion(1)
                    .AddDefaultVersion();
            });

            services.ConfigureBroker(Configuration);
            services.AddMappers();
            services.AddValidators(GetType().Assembly.FullName);
            services.AddFailFastRequest(typeof(Startup));

            services.AddCors();

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseGlobalExceptionHandler(loggerFactory);
            app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseDocumentation();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}