using Dapper;
using LearningHub.Core.Common;
using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LearningHub.Infra.Repository
{
    public class FinalAboutUsRepository : IFinalAboutUsRepository
    {
        private readonly IDbContext _dbContext;

        public FinalAboutUsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InsertAbout(string paragraph, decimal homeId)
        {
            var p = new DynamicParameters();
            p.Add("p_text", paragraph, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("h_id_ref", homeId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("FinalAboutUs_Package.InsertAbout", p, commandType: CommandType.StoredProcedure);
        }

        public List<Finalaboutu> GetAllAbout()
        {
            IEnumerable<Finalaboutu> result = _dbContext.Connection.Query<Finalaboutu>(
                "FinalAboutUs_Package.GetAllAbout",
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }

        public void UpdateAbout(decimal AboutUsId, string paragraph, decimal homeId)
        {
            var p = new DynamicParameters();
            p.Add("a_id", AboutUsId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("p_text", paragraph, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("h_id_ref", homeId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("FinalAboutUs_Package.UpdateAbout", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteAbout(decimal AboutUsId)
        {
            var p = new DynamicParameters();
            p.Add("a_id", AboutUsId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("FinalAboutUs_Package.DeleteAbout", p, commandType: CommandType.StoredProcedure);
        }

        public Finalaboutu GetAboutById(decimal aboutUsId)
        {
            var p = new DynamicParameters();
            p.Add("a_id", aboutUsId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<Finalaboutu> result = _dbContext.Connection.Query<Finalaboutu>(
                "FinalAboutUs_Package.GetAboutById",
                p,
                commandType: CommandType.StoredProcedure
            );

            return result.FirstOrDefault();
        }
    }
}
