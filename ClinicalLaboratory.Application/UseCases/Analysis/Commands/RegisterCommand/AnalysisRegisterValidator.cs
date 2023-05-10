using FluentValidation;

namespace ClinicalLaboratory.Application.UseCases.Analysis.Commands.RegisterCommand
{
    public class AnalysisRegisterValidator : AbstractValidator<AnalysisRegisterCommand>
    {
        public AnalysisRegisterValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El campo Nombre no puede ser nulo")
                .NotEmpty().WithMessage("El campo Nombre no puede ser vacío");

            RuleFor(x => x.State)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(1);
            
        }
    }
}
