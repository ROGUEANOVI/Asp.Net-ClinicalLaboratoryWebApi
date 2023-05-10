using ClinicalLaboratory.Application.Commons.Bases;
using MediatR;

namespace ClinicalLaboratory.Application.UseCases.Analysis.Commands.RegisterCommand
{
    public class AnalysisRegisterCommand : IRequest<BaseResponse<bool>>
    {
        public string? Name { get; set; }
        public int State { get; set; }
    }
}
