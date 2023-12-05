using Dapper;
using LearningHub.Core.Common;
using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LearningHub.Infra.Repository
{
    public class FinalReviewRepository : IFinalReviewRepository
    {
        private readonly IDbContext _dbContext;

        public FinalReviewRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateReview(Finalreview review)
        {
            var p = new DynamicParameters();
            p.Add("RevMess", review.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("RevStar", review.Stars, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("RevStatus", review.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("RevDate", review.Dateposted, dbType: DbType.Date, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("Review_Package.CreateReview", p, commandType: CommandType.StoredProcedure);
        }

        public List<Finalreview> GetAllReviews()
        {
            IEnumerable<Finalreview> result = _dbContext.Connection.Query<Finalreview>(
                "Review_Package.GetAllReview",
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }

        public Finalreview GetReviewById(decimal reviewId)
        {
            var p = new DynamicParameters();
            p.Add("id", reviewId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<Finalreview> result = _dbContext.Connection.Query<Finalreview>(
                "Review_Package.GetReviewById",
                p,
                commandType: CommandType.StoredProcedure
            );

            return result.FirstOrDefault();
        }

        public void UpdateReview(Finalreview review)
        {
            var p = new DynamicParameters();
            p.Add("ID", review.Reviewid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("RevMess", review.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("RevStar", review.Stars, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("RevStatus", review.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("RevDate", review.Dateposted, dbType: DbType.Date, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("Review_Package.UpdateReview", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteReview(decimal reviewId)
        {
            var p = new DynamicParameters();
            p.Add("id", reviewId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("Review_Package.DeleteReview", p, commandType: CommandType.StoredProcedure);
        }
    }
}
