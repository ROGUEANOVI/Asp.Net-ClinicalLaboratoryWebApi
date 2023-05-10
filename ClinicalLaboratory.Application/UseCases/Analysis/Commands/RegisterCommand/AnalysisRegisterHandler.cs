using AutoMapper;
using ClinicalLaboratory.Application.Commons.Bases;
using ClinicalLaboratory.Application.Interfaces;
using MediatR;
using Entity = ClinicalLaboratory.Domain.Entities;

namespace ClinicalLaboratory.Application.UseCases.Analysis.Commands.RegisterCommand
{
    public class AnalysisRegisterHandler : IRequestHandler<AnalysisRegisterCommand, BaseResponse<bool>>
    {
        private readonly IAnalysisRepository _analysisRepository;
        private readonly IMapper _mapper;

        public AnalysisRegisterHandler(IAnalysisRepository analysisRepository, IMapper mapper)
        {
            _analysisRepository = analysisRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(AnalysisRegisterCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var analysis = _mapper.Map<Entity.Analysis>(request);
                response.Data = await _analysisRepository.AnalysisRegister(analysis);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Se resgistró correctamente";
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
