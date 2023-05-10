using FluentValidation;

namespace ClinicalLaboratory.Application.UseCases.Analysis.Commands.EditCommand
{
    public class AnalysisEditValidator : AbstractValidator<AnalysisEditCommand>
    {
        public AnalysisEditValidator()
        {
            RuleFor(x => x.AnalysisId)
                .GreaterThanOrEqualTo(1);

            RuleFor(x => x.Name)
                .NotNull().WithMessage("El campo Nombre no puede ser nulo")
                .NotEmpty().WithMessage("El campo Nombre no puede ser vacío");

            RuleFor(x => x.State)
               .GreaterThanOrEqualTo(0)
               .LessThanOrEqualTo(1);
        }
    }
}
