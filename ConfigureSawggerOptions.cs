using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Version
{
    public class ConfigureSawggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSawggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            var info = new OpenApiInfo() { 
                Title = "My Api JC",
                Version = description.ApiVersion.ToString(),
                Description = "My first test Api version",
                Contact = new OpenApiContact() { 
                    Email = "test@test.com",
                    Name = "Juan Cesar"
                }
            };

            if (description.IsDeprecated)
            {
                info.Description += "This Api has been deprecated";
            }

            return info;
        }
        public void Configure(string name, SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            } 
        }

        public void Configure(SwaggerGenOptions options)
        {
            Configure(options);
        }
    }
}
