using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using LearningHub.Core.Data;
using LearningHub.Infra.Services;

using System.Collections.Generic;
using LearningHub.Core.DTO;
using System.Net.Http.Headers;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalTripController : ControllerBase
    {
        private readonly IFinalTripService _finalTripService;

        public FinalTripController(IFinalTripService finalTripService)
        {
            _finalTripService = finalTripService;
        }

        [HttpGet]
        public List<Finaltrip> GetAllTrips()
        {
            return _finalTripService.GetAllTrips();
        }

        [HttpGet]
        [Route("{tripId}")]
        public Finaltrip GetTripById(int tripId)
        {
            return _finalTripService.GetTripById(tripId);
        }

        [HttpPost]
        public void CreateTrip(CreateTrip trip)
        {
            _finalTripService.CreateTrip(trip);
        }
        [HttpPost]
        [Route("uploadImage")]
        public IActionResult UploadImage()
        {
            var file = Request.Form.Files[0];

            // Get the file name from the Content-Disposition header.
            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

            // Modify the code to save the file with the original file name.
            var fullPath = Path.Combine("C:\\Users\\DELL\\OneDrive\\Desktop\\obidah\\FinalProject\\FinalProject\\src\\assets\\admin\\images", fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            CreateTrip item = new CreateTrip();
            item.imagepath = fileName;

            return Ok(item); // Use Ok() to return a 200 status code.
        }


        [HttpPut]
        public void UpdateTrip(CreateTrip trip)
        {
            _finalTripService.UpdateTrip(trip);
        }

        [HttpDelete]
        [Route("{tripId}")]
        public void DeleteTrip(int tripId)
        {
            _finalTripService.DeleteTrip(tripId);
        }


        [HttpGet]
        [Route("num")]
        public ActionResult<int> GetNumTrips()
        {
            int userCount = _finalTripService.GetNumTrips();
            return Ok(userCount);
        }

        [HttpGet]
        [Route("Report")]
        public List<Report> Report()
        {

            return _finalTripService.Report();
        }


    }
}
