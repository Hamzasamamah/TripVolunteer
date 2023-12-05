using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.Core.Data;
using System.Collections.Generic;
using LearningHub.Core.DTO;

namespace LearningHub.Infra.Services
{
    public interface IFinalUserTripService
    {
        List<MaxTrip> GetMaxTrip();

        List<Finalusertrip> GetAllUserTrips();
        Finalusertrip GetUserTripById(decimal userTripId);
        void CreateUserTrip(Finalusertrip userTrip);
        void UpdateUserTrip(RequestVolunteer userTrip);
        void DeleteUserTrip(decimal userTripId);
        List<VolunteersRequest> GetVolunteersRequest();
        List<TestimonialRequest> GetTestimonialsRequest();
        void BOOKTRIP(BOOKTRIP Trip);
        void RequestVolunteer(RequestVolunteer request);
        void UpdateRequestVolunteer(decimal userTripId);
        void DeleteRequestVolunteer(decimal userTripId);

        // Add the NotifyUserByEmail method signature here
        Task NotifyUserByEmail(string email, int tripId);
        // Task NotifyUserByEmailWithPDF(string email, int tripId);
        Task SendWelcomeEmailWithPaymentDetails(string email, int tripId);
        List<TestimonialRequest> GetTestimonialsapproved();

    }
}
