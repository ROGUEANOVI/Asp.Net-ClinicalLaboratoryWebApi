using ClinicalLaboratory.Domain.Entities;

namespace ClinicalLaboratory.Application.Interfaces
{
    public interface IAnalysisRepository
    {
        Task<IEnumerable<Analysis>> ListAnalysis();

        Task<Analysis> AnalysisById(int analysisId);

        Task<bool> AnalysisRegister(Analysis analysis);

        Task<bool> AnalysisEdit(Analysis analysis);

        Task<bool> AnalysisDelete(int analysisId);
    }
}
