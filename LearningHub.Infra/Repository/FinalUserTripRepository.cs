using Dapper;
using LearningHub.Core.Common;
using LearningHub.Core.Data;
using LearningHub.Core.DTO;
using LearningHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace LearningHub.Infra.Repository
{
    public class FinalUserTripRepository : IFinalUserTripRepository
    {
        private readonly IDbContext _dbContext;

        public FinalUserTripRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Finalusertrip> GetAllUserTrips()
        {
            IEnumerable<Finalusertrip> result = _dbContext.Connection.Query<Finalusertrip>(
                "FinalUserTrips_Package.GETALLUSERTRIPS",
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }

        public Finalusertrip GetUserTripById(decimal userTripId)
        {
            var p = new DynamicParameters();
            p.Add("utID", userTripId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<Finalusertrip> result = _dbContext.Connection.Query<Finalusertrip>(
                "FinalUserTrips_Package.GETUSERTRIPBYID",
                p,
                commandType: CommandType.StoredProcedure
            );

            return result.FirstOrDefault();
        }

        public void CreateUserTrip(Finalusertrip userTrip)
        {
            var p = new DynamicParameters();
            p.Add("uIsVolunteer", userTrip.Isvolunteer, dbType: DbType.Boolean, direction: ParameterDirection.Input);
            p.Add("uUser", userTrip.Userid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("uTrip", userTrip.Tripid, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("FinalUserTrips_Package.CREATEUSERTRIP", p, commandType: CommandType.StoredProcedure);
        }

         public void UpdateRequestVolunteer( decimal userTripId)
        {
            var p = new DynamicParameters();
            p.Add("utID", userTripId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            

            _dbContext.Connection.Execute("FinalUserTrips_Package.UPDATEUSERTRIPVOLUNTEER", p, commandType: CommandType.StoredProcedure);
        }
         public void DeleteRequestVolunteer(decimal userTripId)
        { var p = new DynamicParameters();
        p.Add("utID", userTripId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("FinalUserTrips_Package.DELETEUSERTRIP", p, commandType: CommandType.StoredProcedure);
        }


    public void UpdateUserTrip(RequestVolunteer userTrip)
        {
            var p = new DynamicParameters();
            p.Add("utID", userTrip.Usertripid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("uIsVolunteer", userTrip.Isvolunteer, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("uUser", userTrip.userid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("uTrip", userTrip.Tripid, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("FinalUserTrips_Package.UPDATEUSERTRIP", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteUserTrip(decimal userTripId)
        {
            var p = new DynamicParameters();
            p.Add("utID", userTripId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("FinalUserTrips_Package.DELETEUSERTRIP", p, commandType: CommandType.StoredProcedure);
        }
        public List <VolunteersRequest>  GetVolunteersRequest()
        {
            IEnumerable<VolunteersRequest> result = _dbContext.Connection.Query<VolunteersRequest>(
               "FinalUserTrips_Package.GetAllVolunteers",
               commandType: CommandType.StoredProcedure
           );

            return result.ToList();

        }

        public List<TestimonialRequest> GetTestimonialsRequest()
        {
            try
            {
                IEnumerable<TestimonialRequest> result = _dbContext.Connection.Query<TestimonialRequest>(
                    "FinalUserTrips_Package.GetAllTestimonials",
                    commandType: CommandType.StoredProcedure
                );

                return result.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);  // Log or print the exception message
                return new List<TestimonialRequest>();  // Return an empty list in case of an error
            }
        }

        public void Booktrip(BOOKTRIP Trip)
        {
            var p = new DynamicParameters();
            p.Add("pUserID", Trip.Userid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("pTripID", Trip.Tripid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("card_num", Trip.Cardnumber, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("pcvv", Trip.Cvv, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("price", Trip.Cost, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("FinalUserTrips_Package.BookTrip", p, commandType: CommandType.StoredProcedure);
        }


        public void RequestVolunteer(RequestVolunteer request)
        {
            var p = new DynamicParameters();
            p.Add("pUserID", request.userid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("pTripID", request.Tripid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("FinalUserTrips_Package.volunteer_request", p, commandType: CommandType.StoredProcedure);
        }


        public List<MaxTrip> GetMaxTrip()
        {
            IEnumerable<MaxTrip> result = _dbContext.Connection.Query<MaxTrip>(
                "FinalUserTrips_Package.GetMaxReservationsStat",
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }

        public List<TestimonialRequest> GetTestimonialsapproved()
        {
            try
            {
                IEnumerable<TestimonialRequest> result = _dbContext.Connection.Query<TestimonialRequest>(
                    "FinalUserTrips_Package.GetAllTestimonialsapproved",
                    commandType: CommandType.StoredProcedure
                );

                return result.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);  // Log or print the exception message
                return new List<TestimonialRequest>();  // Return an empty list in case of an error
            }
        }



    }
}
