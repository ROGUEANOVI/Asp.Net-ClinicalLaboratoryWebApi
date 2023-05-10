using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace ClinicalLaboratory.Api.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            var openApi = new OpenApiInfo
            {
                Title = "CLINICAL LABORATORY WEB API",
                Version = "v1",
                Description = "Web api para laboratorio clínico",
                Contact = new OpenApiContact
                {
                    Name = "ROGUEANOVI",
                    Email = "ovidioromero66@gmail.com",
                    Url = new Uri("https://github.com/ROGUEANOVI")
                },
                License = new OpenApiLicense
                {
                    Name = "Usar bajo licencia",
                    Url = new Uri("https://github.com/ROGUEANOVI"),
                }
            };

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc(openApi.Version, openApi);

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Jwt Authentication",
                    Description = "Bearer Token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "Jwt",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                x.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securityScheme, new string[] {} }
                });

            });

            return services;
        }
    }
}
