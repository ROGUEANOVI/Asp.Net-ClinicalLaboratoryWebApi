namespace ClinicalLaboratory.Application.DTOs.Auth.Response
{
    public class LoginUserResponseDTO
    {
        public bool Login { get; set; }
        public string? Token { get; set; }
        public object? User { get; set; }
        public object? Role { get; set; }
        public List<string>? Errors { get; set; }
    }
}
