using ClinicalLaboratory.Application.Commons.Bases;
using FluentValidation.Results;

namespace ClinicalLaboratory.Application.Exceptions
{
    public class FluentValidationException : Exception
    {
        public List<BaseError> Errors { get; }

        public FluentValidationException() : base("Se ha producido uno o más errores de validación") 
        {
            Errors = new List<BaseError>();
        }

        public FluentValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(new BaseError()
                {
                    ErrorMessage = failure.ErrorMessage,
                    PropertyName = failure.PropertyName,
                });
            }
        }
    }
}
