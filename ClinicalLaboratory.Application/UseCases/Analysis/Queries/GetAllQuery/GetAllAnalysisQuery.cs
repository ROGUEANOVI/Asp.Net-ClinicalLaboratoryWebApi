using ClinicalLaboratory.Application.Commons.Bases;
using ClinicalLaboratory.Application.DTOs.Analysis.Response;
using MediatR;

namespace ClinicalLaboratory.Application.UseCases.Analysis.Queries.GetAllQuery
{
    public class GetAllAnalysisQuery : IRequest<BaseResponse<IEnumerable<GetAllAnalysisResponseDTO>>>
    {

    }
}
