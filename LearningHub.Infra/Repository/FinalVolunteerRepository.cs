using Dapper;
using LearningHub.Core.Common;
using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LearningHub.Infra.Repository
{
    public class FinalVolunteerRepository : IFinalVolunteerRepository
    {
        private readonly IDbContext _dbContext;

        public FinalVolunteerRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Finalvolunteer> GetAllVolunteers()
        {
            IEnumerable<Finalvolunteer> result = _dbContext.Connection.Query<Finalvolunteer>(
                "FinalVolunteers_Package.GetAllVolunteers",
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }

        public Finalvolunteer GetVolunteerById(decimal volunteerId)
        {
            var p = new DynamicParameters();
            p.Add("v_id", volunteerId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<Finalvolunteer> result = _dbContext.Connection.Query<Finalvolunteer>(
                "FinalVolunteers_Package.GetVolunteerById",
                p,
                commandType: CommandType.StoredProcedure
            );

            return result.FirstOrDefault();
        }

        public void CreateVolunteer(Finalvolunteer volunteer)
        {
            var p = new DynamicParameters();
            p.Add("ut_id", volunteer.Usertripid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("v_join_date", volunteer.Datejoined, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("v_trip_count", volunteer.Tripscount, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("FinalVolunteers_Package.Create_Volunteer", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateVolunteer(Finalvolunteer volunteer)
        {
            var p = new DynamicParameters();
            p.Add("v_id", volunteer.Volunteerid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("ut_id", volunteer.Usertripid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("v_join_date", volunteer.Datejoined, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("v_trip_count", volunteer.Tripscount, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("FinalVolunteers_Package.Update_Volunteer", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteVolunteer(decimal volunteerId)
        {
            var p = new DynamicParameters();
            p.Add("v_id", volunteerId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("FinalVolunteers_Package.DeleteVolunteer", p, commandType: CommandType.StoredProcedure);
        }
    }
}
