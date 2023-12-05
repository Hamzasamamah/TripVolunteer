using Dapper;
using LearningHub.Core.Common;
using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LearningHub.Infra.Repository
{
    public class FinalTestimonialRepository : IFinalTestimonialRepository
    {
        private readonly IDbContext _dbContext;

        public FinalTestimonialRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateTestimonial(decimal userId, decimal tripId, string message, string status)
        {
            var p = new DynamicParameters();
            p.Add("UID", userId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("TID", tripId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Msg", message, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("StatusN", "PENDING", dbType: DbType.String, direction: ParameterDirection.Input); // Change here to always set to "PENDING"

            _dbContext.Connection.Execute("FinalTestimonials_Package.Create_Testimonial", p, commandType: CommandType.StoredProcedure);
        }

        public List<Finaltestimonial> GetAllTestimonials()
        {
            IEnumerable<Finaltestimonial> result = _dbContext.Connection.Query<Finaltestimonial>(
                "FinalTestimonials_Package.GetAllTestimonials",
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }

        public Finaltestimonial GetTestimonialById(decimal testimonialId)
        {
            var p = new DynamicParameters();
            p.Add("id", testimonialId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<Finaltestimonial> result = _dbContext.Connection.Query<Finaltestimonial>(
                "FinalTestimonials_Package.GetTestimonialById",
                p,
                commandType: CommandType.StoredProcedure
            );

            return result.FirstOrDefault();
        }

        public void UpdateTestimonial(decimal testimonialId, string message, string status)
        {
            var p = new DynamicParameters();
            p.Add("id", testimonialId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Msg", message, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("StatusN", status, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("FinalTestimonials_Package.Update_Testimonial", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteTestimonial(decimal testimonialId)
        {
            var p = new DynamicParameters();
            p.Add("id", testimonialId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("FinalTestimonials_Package.DeleteTestimonial", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateStatus(decimal testimonialId)
        {
            var p = new DynamicParameters();
            p.Add("p_TestimonialID", testimonialId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("FinalTestimonials_Package.UpdateTestimonialStatus", p, commandType: CommandType.StoredProcedure);

        }


    }
}
