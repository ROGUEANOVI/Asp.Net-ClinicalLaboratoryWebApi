namespace ClinicalLaboratory.Infraestructure.Jwt
{
    public class JwtConfig
    {
        public string? SecretKey { get; set; }
        public string? Audience { get; set; }
        public string? Issuer { get; set; }
    }
}
