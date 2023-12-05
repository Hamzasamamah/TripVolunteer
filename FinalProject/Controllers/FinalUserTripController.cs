using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LearningHub.Core.Data;
using LearningHub.Infra.Services;
using System.Collections.Generic;
using LearningHub.Core.DTO;
using DinkToPdf;
using DinkToPdf.Contracts;


namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalUserTripController : ControllerBase
    {
        private readonly IFinalUserTripService _finalUserTripService;

        public FinalUserTripController(IFinalUserTripService finalUserTripService)
        {
            _finalUserTripService = finalUserTripService;
        }

        [HttpGet]
        public List<Finalusertrip> GetAllUserTrips()
        {
            return _finalUserTripService.GetAllUserTrips();
        }

        [HttpGet]
        [Route("{userTripId}")]
        public Finalusertrip GetUserTripById(decimal userTripId)
        {
            return _finalUserTripService.GetUserTripById(userTripId);
        }

        [HttpPost]
        public void CreateUserTrip(Finalusertrip userTrip)
        {
            _finalUserTripService.CreateUserTrip(userTrip);
        }

        [HttpPut]
        [Route("Update")]
        public void UpdateUserTrip(RequestVolunteer userTrip)
        {
            _finalUserTripService.UpdateUserTrip(userTrip);
        }

        [HttpDelete]
        [Route("{userTripId}")]
        public void DeleteUserTrip(decimal userTripId)
        {
            _finalUserTripService.DeleteUserTrip(userTripId);
        }

        [HttpGet]
        [Route ("getvolunteersrequest")]
        public List<VolunteersRequest> GetVolunteersRequests()
        {
            return _finalUserTripService.GetVolunteersRequest();
        }
        [HttpGet]
        [Route ("getatestimonialsrequest")]
        public List<TestimonialRequest> GetTestimonialsRequest()
        {
            return _finalUserTripService.GetTestimonialsRequest();
        }
        [HttpGet]
        [Route("getatestimonialsapproved")]
        public List<TestimonialRequest> GetTestimonialsapproved()
        {
            return _finalUserTripService.GetTestimonialsapproved();
        }

        [HttpPost]
        [Route("booktrip")]
        public void BOOKTRIP(BOOKTRIP Trip)
        {
            _finalUserTripService.BOOKTRIP(Trip);
        }
        [HttpPost]
        [Route("requestvolunteer")]
        public void RequestVolunteer(RequestVolunteer request)
        {
            _finalUserTripService.RequestVolunteer(request);
        }

        [HttpPut]
        [Route("volunteer/{userTripId}")]
        public void UpdateRequestVolunteer(decimal userTripId)
        {
            _finalUserTripService.UpdateRequestVolunteer(userTripId);

        }
        [Route("api/usertrip/notify")]
        [HttpPost]
        public async Task<IActionResult> NotifyUserByEmail([FromBody] NotifyRequest request)
        {
            try
            {
                await _finalUserTripService.NotifyUserByEmail(request.Email, request.TripId);
                return Ok("Email sent successfully.");
            }
            catch (Exception ex)
            {
                // log the exception if you have logging set up.
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }
        [HttpGet]
        [Route("max")]
        public List<MaxTrip> GetMaxTrip()
        {
            return _finalUserTripService.GetMaxTrip();
        }


        [Route("api/usertrip/pdf")]
        [HttpPost]
        public async Task <IActionResult> SendWelcomeEmailWithPaymentDetails([FromBody] NotifyRequest request)
        {
            try
            {
                await _finalUserTripService.SendWelcomeEmailWithPaymentDetails(request.Email, request.TripId);
                return Ok("Email sent successfully.");
            }
            catch (Exception ex)
            {
                // log the exception if you have logging set up.
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }
         public class NotifyRequest
        {
            public string Email { get; set; }
            public int TripId { get; set; }

        }



        //[Route("api/usertrip/notifypdf")]
        //[HttpPost]
        //public async Task<IActionResult> NotifyUserByEmailWithPDF([FromBody] NotifyRequest request)
        //{
        //    try
        //    {
        //        await _finalUserTripService.NotifyUserByEmailWithPDF(request.Email, request.TripId);
        //        return Ok("Email with PDF sent successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Exception caught: {ex}");
        //      ; return BadRequest($"An error occurred: {ex.Message}");
        //    }
        //}

        //public class NotifyRequestpdf
        //{
        //    public string Email { get; set; }
        //    public int TripId { get; set; }
        //}

        //[HttpDelete]
        //[Route("{userTripId}")]
        //public  void DeleteRequestVolunteer(decimal userTripId)
        //{
        //    _finalUserTripService.DeleteRequestVolunteer(userTripId);
        //}
    }
}
