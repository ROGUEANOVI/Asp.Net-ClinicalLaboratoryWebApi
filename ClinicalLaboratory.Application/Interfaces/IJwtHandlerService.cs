namespace ClinicalLaboratory.Application.Interfaces
{
    public interface IJwtHandlerService
    {
        string GenerateJwt(IJwtParameters parameters);
    }
}
