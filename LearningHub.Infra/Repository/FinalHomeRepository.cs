using Dapper;
using LearningHub.Core.Common;
using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LearningHub.Infra.Repository
{
    public class FinalHomeRepository : IFinalHomeRepository
    {
        private readonly IDbContext _dbContext;

        public FinalHomeRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InsertHome(string paragraph)
        {
            var p = new DynamicParameters();
            p.Add("p_para", paragraph, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("FinalHome_Package.InsertHome", p, commandType: CommandType.StoredProcedure);
        }

        public List<Finalhome> GetAllHomes()
        {
            IEnumerable<Finalhome> result = _dbContext.Connection.Query<Finalhome>(
                "FinalHome_Package.GetAllHomes",
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }

        public void UpdateHome(decimal homeId, string paragraph)
        {
            var p = new DynamicParameters();
            p.Add("h_id", homeId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("p_para", paragraph, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("FinalHome_Package.UpdateHome", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteHome(decimal homeId)
        {
            var p = new DynamicParameters();
            p.Add("h_id", homeId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("FinalHome_Package.DeleteHome", p, commandType: CommandType.StoredProcedure);
        }

        public Finalhome GetHomeById(decimal homeId)
        {
            var p = new DynamicParameters();
            p.Add("h_id", homeId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<Finalhome> result = _dbContext.Connection.Query<Finalhome>(
                "FinalHome_Package.GetHomeById",
                p,
                commandType: CommandType.StoredProcedure
            );

            return result.FirstOrDefault();
        }
    }
}
