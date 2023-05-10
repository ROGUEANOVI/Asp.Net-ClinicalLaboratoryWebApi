using AutoMapper;
using ClinicalLaboratory.Application.DTOs.Analysis.Response;
using ClinicalLaboratory.Application.UseCases.Analysis.Commands.EditCommand;
using ClinicalLaboratory.Application.UseCases.Analysis.Commands.RegisterCommand;
using ClinicalLaboratory.Domain.Entities;

namespace ClinicalLaboratory.Application.Mappings
{
    public class AnalysisProfile : Profile
    {
        public AnalysisProfile()
        {
            CreateMap<Analysis, GetAllAnalysisResponseDTO>()
                .ForMember(
                    x => x.StateAnalysis,
                    x => x.MapFrom(y => y.State == 1 ? "ACTIVO" : "INACTIVO")
                )
                .ReverseMap();

            CreateMap<Analysis, GetAnalysisByIdResponseDTO>()
                .ReverseMap() ;

            CreateMap<AnalysisRegisterCommand, Analysis>()
                .ReverseMap();

            CreateMap<AnalysisEditCommand, Analysis>()
               .ReverseMap();
        }
    }
}
