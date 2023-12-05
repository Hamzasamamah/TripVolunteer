using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using System.Collections.Generic;
using System.Linq;
using LearningHub.Core.DTO;

namespace LearningHub.Infra.Services
{
    public class FinalTripService : IFinalTripService
    {
        private readonly IFinalTripRepository _finalTripRepository;

        public FinalTripService(IFinalTripRepository finalTripRepository)
        {
            _finalTripRepository = finalTripRepository;
        }

        public List<Finaltrip> GetAllTrips()
        {
            return _finalTripRepository.GetAllTrips();
        }

        public void CreateTrip(CreateTrip trip)
        {
            // Any additional business logic before creating a trip
            _finalTripRepository.CreateTrip(trip);
        }

        public void UpdateTrip(CreateTrip trip)
        {
            // Any additional business logic before updating a trip
            _finalTripRepository.UpdateTrip(trip);
        }

        public void DeleteTrip(int tripId)
        {
            // Any additional business logic before deleting a trip
            _finalTripRepository.DeleteTrip(tripId);
        }

        public Finaltrip GetTripById(int tripId)
        {
            return _finalTripRepository.GetTripById(tripId);
        }

        public int GetNumTrips()
        {
            return _finalTripRepository.GetNumTrips();
        }

        public List<Report> Report()
        {
            return _finalTripRepository.Report();
        }

    }
}
