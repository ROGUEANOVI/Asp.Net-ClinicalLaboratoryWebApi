using ClinicalLaboratory.Application.Interfaces;

namespace ClinicalLaboratory.Application.DTOs.Auth.Request
{
    public class JwtParameters : IJwtParameters
    {
        public string Id { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string RoleName { get; set; } = null!;
    }
}
