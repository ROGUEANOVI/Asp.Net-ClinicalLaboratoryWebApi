using AutoMapper;
using ClinicalLaboratory.Application.Commons.Bases;
using ClinicalLaboratory.Application.Interfaces;
using MediatR;

namespace ClinicalLaboratory.Application.UseCases.Analysis.Commands.DeleteCommand
{
    public class AnalysisDeleteHandler : IRequestHandler<AnalysisDeleteCommand, BaseResponse<bool>>
    {
        private readonly IAnalysisRepository _analysisRepository;

        public AnalysisDeleteHandler(IAnalysisRepository analysisRepository)
        {
            _analysisRepository = analysisRepository;
        }

        public async Task<BaseResponse<bool>> Handle(AnalysisDeleteCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                response.Data = await   _analysisRepository.AnalysisDelete(request.AnalysisId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Se eliminó correctamente";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
