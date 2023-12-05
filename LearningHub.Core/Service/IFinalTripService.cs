using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LearningHub.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using LearningHub.Core.DTO;
using LearningHub.Core.Repository;

namespace LearningHub.Infra.Services
{
    public interface IFinalTripService
    {
        List<Finaltrip> GetAllTrips();
        void CreateTrip(CreateTrip trip);
        void UpdateTrip(CreateTrip trip);
        void DeleteTrip(int tripId);
        Finaltrip GetTripById(int tripId);
        public int GetNumTrips();
        List<Report> Report();
       


    }
}
