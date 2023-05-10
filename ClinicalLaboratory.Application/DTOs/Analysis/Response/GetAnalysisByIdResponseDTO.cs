namespace ClinicalLaboratory.Application.DTOs.Analysis.Response
{
    public class GetAnalysisByIdResponseDTO
    {
        public int AnalysisId { get; set; }
        public string? Name { get; set; }
        public int State { get; set; }
    }
}
