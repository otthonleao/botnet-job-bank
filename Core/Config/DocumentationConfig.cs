using Microsoft.OpenApi.Models;

namespace JobBank.Core.Config;

public static class DocumentationConfig
{
    public static void RegisterDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Job Bank API",
                Version = "v1",
                Description = "API que simula um portal de empregos",
                Contact = new OpenApiContact
                {
                    Name = "Otthon Leão",
                    Email = "otthonleao@hotmail.com",
                    Url = new("https://www.linkedin.com/in/otthonleao/")
                }
            });
        });
    }
}