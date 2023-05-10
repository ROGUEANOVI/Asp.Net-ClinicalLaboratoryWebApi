using ClinicalLaboratory.Application.Commons.Bases;
using MediatR;

namespace ClinicalLaboratory.Application.UseCases.Analysis.Commands.DeleteCommand
{
    public class AnalysisDeleteCommand : IRequest<BaseResponse<bool>>
    {
        public int AnalysisId { get; set; }
    }
}
