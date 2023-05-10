using ClinicalLaboratory.Api.Middlewares;

namespace ClinicalLaboratory.Api.Extensions
{
    public static class AppExtension
    {
        public static void UseErrorHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
