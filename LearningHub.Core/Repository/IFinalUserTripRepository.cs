using LearningHub.Core.Data;
using LearningHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Repository
{
    public interface IFinalUserTripRepository
    {
        List<Finalusertrip> GetAllUserTrips();
        Finalusertrip GetUserTripById(decimal userTripId);
        void CreateUserTrip(Finalusertrip userTrip);
        void UpdateUserTrip(RequestVolunteer userTrip);
        void DeleteUserTrip(decimal userTripId);
         List<VolunteersRequest> GetVolunteersRequest();
        List<TestimonialRequest> GetTestimonialsRequest();
        void Booktrip(BOOKTRIP Trip);
        void RequestVolunteer(RequestVolunteer request);

        void UpdateRequestVolunteer( decimal userTripId);

        void DeleteRequestVolunteer(decimal userTripId);
        List<MaxTrip> GetMaxTrip();
        List<TestimonialRequest> GetTestimonialsapproved();


    }

}

