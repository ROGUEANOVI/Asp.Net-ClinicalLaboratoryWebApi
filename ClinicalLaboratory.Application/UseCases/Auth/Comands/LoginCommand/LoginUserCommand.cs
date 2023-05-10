using ClinicalLaboratory.Application.Commons.Bases;
using ClinicalLaboratory.Application.DTOs.Auth.Response;
using MediatR;

namespace ClinicalLaboratory.Application.UseCases.Auth.Comands.LoginCommand
{
    public class LoginUserCommand : IRequest<BaseResponse<LoginUserResponseDTO>>
    {
        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}
