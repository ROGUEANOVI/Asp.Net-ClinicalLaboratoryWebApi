using ClinicalLaboratory.Application.Interfaces;
using ClinicalLaboratory.Infraestructure.Jwt;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicalLaboratory.Infraestructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfraestructure(this IServiceCollection services)
        {
            services.AddScoped<IJwtHandlerService, JwtHandlerService>();

            return services;
        }
    }
}
