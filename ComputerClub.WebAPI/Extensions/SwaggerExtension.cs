using System.Text.Json;
using FastEndpoints.Swagger;

namespace ComputerClub.WebAPI.Extensions;

public static class SwaggerExtension
{
    public static void AddSwagger(this IServiceCollection service)
    {
        service.SwaggerDocument(options =>
        {
            options.DocumentSettings = settings =>
            {
                settings.DocumentName = "ComputerClub";
                settings.Description = "API computer club";
                settings.Title = "Computer club";
                settings.Version = "V1";
            };
            options.EnableJWTBearerAuth = true;
            options.TagCase = TagCase.TitleCase;
            options.AutoTagPathSegmentIndex = 0;
            options.SerializerSettings = serializerOptions =>
            {
                serializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                serializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
            };
        });
    }
}