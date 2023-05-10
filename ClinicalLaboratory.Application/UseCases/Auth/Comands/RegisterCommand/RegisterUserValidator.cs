using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalLaboratory.Application.UseCases.Auth.Comands.RegisterCommand
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull().WithMessage("El campo Nombre no puede ser nulo")
                .NotEmpty().WithMessage("El campo Nombre no puede ser vacío");

            RuleFor(x => x.LastName)
                .NotNull().WithMessage("El campo Apellido no puede ser nulo")
                .NotEmpty().WithMessage("El campo Apellido no puede ser vacío");

            RuleFor(x => x.Email)
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible);

            RuleFor(x => x.Password)
                .NotNull().WithMessage("El campo Contraseña no puede ser nulo")
                .NotEmpty().WithMessage("El campo Contraseña no puede ser vacío");

            RuleFor(x => x.RoleName)
                .NotNull().WithMessage("El campo Rol no puede ser nulo")
                .NotEmpty().WithMessage("El campo Rol no puede ser vacío");
        }
    }
}
