using ClinicalLaboratory.Application.Interfaces;
using ClinicalLaboratory.Persistence.Contexts;
using ClinicalLaboratory.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicalLaboratory.Persistence.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();
            services.AddScoped<IAnalysisRepository, AnalysisRepository>();

            return services;
        }
    }
}
