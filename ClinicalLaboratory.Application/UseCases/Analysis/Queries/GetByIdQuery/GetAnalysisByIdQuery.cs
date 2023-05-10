using ClinicalLaboratory.Application.Commons.Bases;
using ClinicalLaboratory.Application.DTOs.Analysis.Response;
using MediatR;

namespace ClinicalLaboratory.Application.UseCases.Analysis.Queries.GetByIdQuery
{
    public class GetAnalysisByIdQuery : IRequest<BaseResponse<GetAnalysisByIdResponseDTO>>
    {
        public int AnalysisId { get; set; }
    }
}
