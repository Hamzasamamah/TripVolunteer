using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LearningHub.Core.Data;
using LearningHub.Infra.Services;
using LearningHub.Core.Services;
using LearningHub.Core.DTO;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalTestimonialController : ControllerBase
    {
        private readonly IFinalTestimonialService _finalTestimonialService;

        public FinalTestimonialController(IFinalTestimonialService finalTestimonialService)
        {
            _finalTestimonialService = finalTestimonialService;
        }

        [HttpGet]
        public List<Finaltestimonial> GetAllTestimonials()
        {
            return _finalTestimonialService.GetAllTestimonials();
        }

        [HttpGet]
        [Route("{testimonialId}")]
        public Finaltestimonial GetTestimonialById(decimal testimonialId)
        {
            return _finalTestimonialService.GetTestimonialById(testimonialId);
        }

        [HttpPost]
        public void CreateTestimonial([FromBody] TestimonialDTO testimonial)
        {
            _finalTestimonialService.CreateTestimonial(testimonial.UserId, testimonial.TripId, testimonial.Message, testimonial.Status);
        }


        [HttpPut]
        [Route("{testimonialId}")]
        public void UpdateTestimonial(decimal testimonialId, string message, string status)
        {
            _finalTestimonialService.UpdateTestimonial(testimonialId, message, status);
        }
       

        [HttpDelete]
        [Route("{testimonialId}")]
        public void DeleteTestimonial(decimal testimonialId)
        {
            _finalTestimonialService.DeleteTestimonial(testimonialId);
        }




        [HttpPut]
        [Route("Updatestatus")]
        public void Updatestatus(decimal testimonialId)
        {
            _finalTestimonialService.UpdateStatus(testimonialId);
        }

    }
}
