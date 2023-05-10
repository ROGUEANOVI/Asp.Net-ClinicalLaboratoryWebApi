namespace ClinicalLaboratory.Application.DTOs.Analysis.Response
{
    public class GetAllAnalysisResponseDTO
    {
        public int AnalysisId { get; set; }
        public string? Name { get; set; }
        public int state { get; set; }
        public string? StateAnalysis { get; set; }
        public DateTime AuditCreateDate { get; set; } 
    }
}
