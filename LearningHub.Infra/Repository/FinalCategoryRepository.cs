using Dapper;
using LearningHub.Core.Common;
using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LearningHub.Infra.Repository
{
    public class FinalCategoryRepository : IFinalCategoryRepository
    {
        private readonly IDbContext _dbContext;

        public FinalCategoryRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Finalcategory> GetAllCategory()
        {
            IEnumerable<Finalcategory> result = _dbContext.Connection.Query<Finalcategory>
                ("FINALCATEGORIES_PACKAGE.GetAllCategories", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void CreateCategory(Finalcategory finalCategory)
        {
            var p = new DynamicParameters();
            p.Add("CName", finalCategory.Categoryname, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("FINALCATEGORIES_PACKAGE.Create_Category", p,
                commandType: CommandType.StoredProcedure);
        }

        public void UpdateCategory(Finalcategory finalCategory)
        {
            var p = new DynamicParameters();
            p.Add("id", finalCategory.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CName", finalCategory.Categoryname, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("FINALCATEGORIES_PACKAGE.Update_Category", p,
                commandType: CommandType.StoredProcedure);
        }

        public void DeleteCategory(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("FINALCATEGORIES_PACKAGE.DeleteCategory", p,
                commandType: CommandType.StoredProcedure);
        }

        public Finalcategory GetCategoryById(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Finalcategory>("FINALCATEGORIES_PACKAGE.GetCategoryById",
                p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

    }
}
