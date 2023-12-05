using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LearningHub.Core.Data;
using LearningHub.Infra.Services;
using LearningHub.Core.Services;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalAboutUsController : ControllerBase
    {
        private readonly IFinalAboutUsService _finalAboutUsService;

        public FinalAboutUsController(IFinalAboutUsService finalAboutUsService)
        {
            _finalAboutUsService = finalAboutUsService;
        }

        [HttpGet]
        public ActionResult<List<Finalaboutu>> GetAllAbout()
        {
            return Ok(_finalAboutUsService.GetAllAbout());
        }

        [HttpGet("{aboutUsId}")]
        public ActionResult<Finalaboutu> GetAboutById(decimal aboutUsId)
        {
            var about = _finalAboutUsService.GetAboutById(aboutUsId);
            if (about == null)
            {
                return NotFound();
            }
            return Ok(about);
        }

        [HttpPost]
        public IActionResult InsertAbout([FromBody] AboutUsDto aboutUsDto)
        {
            try
            {
                _finalAboutUsService.InsertAbout(aboutUsDto.Paragraph, aboutUsDto.HomeId);
                return Ok("About Us entry created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{aboutUsId}")]
        public IActionResult UpdateAbout(decimal aboutUsId, [FromBody] AboutUsDto aboutUsDto)
        {
            try
            {
                _finalAboutUsService.UpdateAbout(aboutUsId, aboutUsDto.Paragraph, aboutUsDto.HomeId);
                return Ok("About Us entry updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{aboutUsId}")]
        public IActionResult DeleteAbout(decimal aboutUsId)
        {
            try
            {
                _finalAboutUsService.DeleteAbout(aboutUsId);
                return Ok("About Us entry deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    public class AboutUsDto
    {
        public string Paragraph { get; set; }
        public decimal HomeId { get; set; }
    }
}
