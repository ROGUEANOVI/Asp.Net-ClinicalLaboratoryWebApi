using ClinicalLaboratory.Application.Commons.Bases;
using MediatR;

namespace ClinicalLaboratory.Application.UseCases.Auth.Comands.RegisterCommand
{
    public class RegisterUserCommand : IRequest<BaseResponse<bool>>
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? RoleName { get; set; }

    }
}
