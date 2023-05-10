namespace ClinicalLaboratory.Application.Interfaces
{
    public interface IJwtParameters
    {
        string Id { get; set; }
        string UserName { get; set; }
        string PasswordHash { get; set; }
        string RoleName { get; set; }
    }
}
