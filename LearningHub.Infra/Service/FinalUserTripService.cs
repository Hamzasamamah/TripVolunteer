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
using LearningHub.Core.Services;
using System.Drawing;
using System.Xml.Linq;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using DinkToPdf;
using DinkToPdf.Contracts;


namespace LearningHub.Infra.Services
{
    public class FinalUserTripService : IFinalUserTripService
    {
        private readonly IFinalUserTripRepository _finalUserTripRepository;
        private readonly IEmailService _emailService;
        private readonly IFinalTripRepository _finalTripRepository;



        public FinalUserTripService(IFinalUserTripRepository finalUserTripRepository, IEmailService emailService, IFinalTripRepository finalTripRepository)
        {
            _finalUserTripRepository = finalUserTripRepository;
            _emailService = emailService;
            _finalTripRepository = finalTripRepository;
        }

        public List<Finalusertrip> GetAllUserTrips()
        {
            return _finalUserTripRepository.GetAllUserTrips();
        }

        public Finalusertrip GetUserTripById(decimal userTripId)
        {
            return _finalUserTripRepository.GetUserTripById(userTripId);
        }

        public void CreateUserTrip(Finalusertrip userTrip)
        {
            // Any additional business logic before creating a user trip
            _finalUserTripRepository.CreateUserTrip(userTrip);
        }

        public void UpdateUserTrip(RequestVolunteer userTrip)
        {
            // Any additional business logic before updating a user trip
            _finalUserTripRepository.UpdateUserTrip(userTrip);
        }

        public void DeleteUserTrip(decimal userTripId)
        {
            // Any additional business logic before deleting a user trip
            _finalUserTripRepository.DeleteUserTrip(userTripId);
        }

        public List<VolunteersRequest> GetVolunteersRequest()
        { return  _finalUserTripRepository.GetVolunteersRequest();
        }
        public List<TestimonialRequest> GetTestimonialsRequest()
        {
            return _finalUserTripRepository.GetTestimonialsRequest();
        }
        public List<TestimonialRequest> GetTestimonialsapproved()
        {
            return _finalUserTripRepository.GetTestimonialsapproved();
        }
        public void BOOKTRIP(BOOKTRIP Trip)
        {
            // Any additional business logic before creating a user trip
            _finalUserTripRepository.Booktrip(Trip);
        }
        public void RequestVolunteer(RequestVolunteer request)
        {
            // Any additional business logic before creating a user trip
            _finalUserTripRepository.RequestVolunteer(request);
        }

        public void UpdateRequestVolunteer(decimal userTripId)
        {
            _finalUserTripRepository.UpdateRequestVolunteer(userTripId);
        }

        public void DeleteRequestVolunteer(decimal userTripId)
        {
            _finalUserTripRepository.DeleteRequestVolunteer(userTripId);
        }


        public async Task NotifyUserByEmail(string email, int tripId)
        {
            Finaltrip tripDetails = _finalTripRepository.GetTripById(tripId);

            string subject = "Your Trip Details and Warm Welcome!";
            string body = $"Hello and Welcome, \n\n" +
                          $"First off, we would like to express our heartfelt gratitude for choosing to volunteer for our trip. Your selfless gesture is greatly appreciated, and we're excited to have you onboard. Here's a gentle reminder of the journey you're about to embark on:\n\n" +
                          $"Trip ID: {tripDetails.Tripid}\n" +
                          $"Trip Name: {tripDetails.Tripname}\n" +
                          $"Description: {tripDetails.Description}\n" +
                          $"Start Date: {tripDetails.Startdate}\n" +
                          $"End Date: {tripDetails.Enddate}\n" +
                          $"Start Destination: {tripDetails.Startdestination}\n" +
                          $"Final Destination: {tripDetails.Finaldestination}\n" +
                          $"Location: {tripDetails.Location}\n" +
                          $"Maximum Participants: {tripDetails.Maximumparticipants}\n" +
                          $"Current Participants: {tripDetails.Currentparticipants}\n" +
                          $"Cost: {tripDetails.Cost}\n" +
                          $"Map Link: {tripDetails.Maplink}\n" +
                          $"Status: {tripDetails.Status}\n" +
                          $"Category ID: {tripDetails.Categoryid}\n\n" +
                          $"Thank you once again for volunteering. Let's make this a memorable trip! Safe travels! ";

            await _emailService.SendEmailAsync(email, subject, body);
        }

        public async Task SendWelcomeEmailWithPaymentDetails(string email, int tripId)
        {
            Finaltrip tripDetails = _finalTripRepository.GetTripById(tripId);

            string subject = "Welcome to Your Adventure!";
            string body = $"Hello and Welcome, \n\n" +
                          $"First off, we would like to express our heartfelt gratitude for choosing to join our trip. Your participation is greatly appreciated, and we're thrilled to have you onboard. Here are the details of your upcoming adventure:\n\n" +
                          $"Trip Name: {tripDetails.Tripname}\n" +
                          $"Start Date: {tripDetails.Startdate}\n" +
                          $"End Date: {tripDetails.Enddate}\n" +
                          $"Start Destination: {tripDetails.Startdestination}\n" +
                          $"Final Destination: {tripDetails.Finaldestination}\n" +
                          $"Location: {tripDetails.Location}\n" +
                          $"Cost: {tripDetails.Cost:C}\n" + // Display the trip cost in currency format
                          $"Map Link: {tripDetails.Maplink}\n" +
                          $"Status: {tripDetails.Status}\n" +
                          $"Category ID: {tripDetails.Categoryid}\n\n" +
                          $"Thank you for making a payment of {tripDetails.Cost:C} for your trip. We are all set to embark on this memorable journey together. Safe travels!\n\n" +
                          $"Best Regards,\n Dina Alomari";

            await _emailService.SendEmailAsync(email, subject, body);
        }
        public List<MaxTrip> GetMaxTrip()
        {
            return _finalUserTripRepository.GetMaxTrip();
        }



       


    }

}
