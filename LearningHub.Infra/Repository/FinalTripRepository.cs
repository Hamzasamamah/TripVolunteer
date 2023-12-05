using Dapper;
using LearningHub.Core.Common;
using LearningHub.Core.Data;
using LearningHub.Core.DTO;
using LearningHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LearningHub.Infra.Repository
{
    public class FinalTripRepository : IFinalTripRepository
    {
        private readonly IDbContext _dbContext;

        public FinalTripRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Finaltrip> GetAllTrips()
        {
            IEnumerable<Finaltrip> result = _dbContext.Connection.Query<Finaltrip>(
                "FinalTrips_Package.GetAllTrips",
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }

        public Finaltrip GetTripById(int tripId)
        {
            var p = new DynamicParameters();
            p.Add("t_id", tripId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Finaltrip> result = _dbContext.Connection.Query<Finaltrip>(
                "FinalTrips_Package.GetTripById",
                p,
                commandType: CommandType.StoredProcedure
            );

            return result.FirstOrDefault();
        }

        public void CreateTrip(CreateTrip trip)
        {
            var p = new DynamicParameters();
            p.Add("t_name", trip.Tripname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("t_desc", trip.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("t_start_date", trip.Startdate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("t_end_date", trip.Enddate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("t_start_dest", trip.Startdestination, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("t_final_dest", trip.Finaldestination, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("t_location", trip.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("t_max_participants", trip.Maximumparticipants, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("t_cost", trip.Cost, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("t_map_link", trip.Maplink, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("t_status", trip.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("t_category_id", trip.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("t_Lat", trip.Lat, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("t_Lng", trip.Lng, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("ImgPath", trip.imagepath, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("FinalTrips_Package.Create_Trip", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateTrip(CreateTrip trip)
        {
            var p = new DynamicParameters();
            p.Add("t_id", trip.Tripid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("t_name", trip.Tripname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("t_desc", trip.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("t_start_date", trip.Startdate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("t_end_date", trip.Enddate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("t_start_dest", trip.Startdestination, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("t_final_dest", trip.Finaldestination, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("t_location", trip.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("t_max_participants", trip.Maximumparticipants, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("t_cost", trip.Cost, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("t_map_link", trip.Maplink, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("t_status", trip.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("t_category_id", trip.Categoryid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("t_Lat", trip.Lat, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("t_Lng", trip.Lng, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("ImgPath", trip.imagepath, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("FinalTrips_Package.Update_Trip", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteTrip(int tripId)
        {
            var p = new DynamicParameters();
            p.Add("t_id", tripId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("FinalTrips_Package.DeleteTrip", p, commandType: CommandType.StoredProcedure);
        }
        


        public int GetNumTrips()
        {
            IEnumerable<Finaltrip> result = _dbContext.Connection.Query<Finaltrip>
                ("FinalTrips_Package.GetAllTrips", commandType: CommandType.StoredProcedure);
            return result.ToList().Count;
        }

        public List<Report> Report()
        {
            IEnumerable<Report> result = _dbContext.Connection.Query<Report>(
                 "FinalTrips_Package.Getreportsbenefits",
                 commandType: CommandType.StoredProcedure
             );

            return result.ToList();

        }
    }
}
