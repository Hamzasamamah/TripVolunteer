using LearningHub.Core.Data;
using LearningHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningHub.Core.Repository
{
    public interface IFinalTripRepository
    {
        List<Finaltrip> GetAllTrips();
        public int GetNumTrips();
        Finaltrip GetTripById(int tripId);
        void CreateTrip(CreateTrip trip);
        void UpdateTrip(CreateTrip trip);
        void DeleteTrip(int tripId);
        List<Report> Report();

    }
}
