using ClinicalLaboratory.Application.Interfaces;
using ClinicalLaboratory.Domain.Entities;
using ClinicalLaboratory.Persistence.Contexts;
using Dapper;
using System.Data;

namespace ClinicalLaboratory.Persistence.Repositories
{
    public class AnalysisRepository : IAnalysisRepository
    {
        private readonly AppDbContext _context;

        public AnalysisRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Analysis>> ListAnalysis()
        {
            using var connection = _context.CreateConnection;

            var query = "sp_AnalysisList";

            var analysis = await connection.QueryAsync<Analysis>(query, commandType: CommandType.StoredProcedure);
            
            return analysis;
        }
        public async Task<Analysis> AnalysisById(int analysisId)
        {
            using var connection = _context.CreateConnection;

            var query = "sp_AnalysisById";

            var parameters = new DynamicParameters();
            parameters.Add("AnalysisId", analysisId);

            var analysis = await connection
                .QuerySingleOrDefaultAsync<Analysis>(
                    query, param: parameters, commandType: CommandType.StoredProcedure
                );
            
            return analysis;
        }

        public async Task<bool> AnalysisRegister(Analysis analysis)
        {
            using var connection = _context.CreateConnection;

            var query = "sp_AnalysisRegister";

            var parameters = new DynamicParameters();
            parameters.Add("Name", analysis.Name);
            parameters.Add("State", analysis.State);
            parameters.Add("AuditCreateDate", DateTime.UtcNow);

            var recordsAffected = await connection
                .ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
            
            return recordsAffected > 0;

        }

        public async Task<bool> AnalysisEdit(Analysis analysis)
        {
            using var connection = _context.CreateConnection;

            var query = "sp_AnalysisEdit";

            var parameters = new DynamicParameters();
            parameters.Add("AnalysisId", analysis.AnalysisId);
            parameters.Add("Name", analysis.Name);
            parameters.Add("State", analysis.State);

            var recordsAffected = await connection
                .ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

            return recordsAffected > 0;
        }

        public async Task<bool> AnalysisDelete(int analysisId)
        {
            using var connection = _context.CreateConnection;

            var query = "sp_AnalysisDelete";

            var parameters = new DynamicParameters();
            parameters.Add("AnalysisId", analysisId);

            var recordsAffected = await connection
               .ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

            return recordsAffected > 0;
        }
    }
}
