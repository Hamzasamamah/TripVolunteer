using Dapper;
using LearningHub.Core.Common;
using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LearningHub.Infra.Repository
{
    public class FinalUserRoleRepository : IFinalUserRoleRepository
    {
        private readonly IDbContext _dbContext;

        public FinalUserRoleRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateUserRole(string roleName)
        {
            var p = new DynamicParameters();
            p.Add("RName", roleName, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("FinalUserRoles_Package.Create_UserRole", p, commandType: CommandType.StoredProcedure);
        }

        public List<Finaluserrole> GetAllUserRoles()
        {
            IEnumerable<Finaluserrole> result = _dbContext.Connection.Query<Finaluserrole>(
                "FinalUserRoles_Package.GetAllUserRoles",
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }

        public Finaluserrole GetUserRoleById(decimal roleId)
        {
            var p = new DynamicParameters();
            p.Add("id", roleId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<Finaluserrole> result = _dbContext.Connection.Query<Finaluserrole>(
                "FinalUserRoles_Package.GetUserRoleById",
                p,
                commandType: CommandType.StoredProcedure
            );

            return result.FirstOrDefault();
        }

        public void UpdateUserRole(decimal roleId, string roleName)
        {
            var p = new DynamicParameters();
            p.Add("id", roleId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("RName", roleName, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("FinalUserRoles_Package.Update_UserRole", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteUserRole(decimal roleId)
        {
            var p = new DynamicParameters();
            p.Add("id", roleId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("FinalUserRoles_Package.DeleteUserRole", p, commandType: CommandType.StoredProcedure);
        }
    }
}
