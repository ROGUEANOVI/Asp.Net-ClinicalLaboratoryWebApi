using ClinicalLaboratory.Application.Commons.Bases;
using MediatR;

namespace ClinicalLaboratory.Application.UseCases.Analysis.Commands.EditCommand
{
    public class AnalysisEditCommand : IRequest<BaseResponse<bool>>
    {
        public int AnalysisId { get; set; }
        public string? Name { get; set; }
        public int State { get; set; }
    }
}
