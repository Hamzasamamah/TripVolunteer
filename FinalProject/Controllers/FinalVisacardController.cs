using Microsoft.AspNetCore.Mvc;
using LearningHub.Core.Data;
using LearningHub.Core.Services;
using System.Collections.Generic;

namespace LearningHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalVisacardController : ControllerBase
    {
        private readonly IFinalVisacardService _finalVisacardService;

        public FinalVisacardController(IFinalVisacardService finalVisacardService)
        {
            _finalVisacardService = finalVisacardService;
        }

        // GET: api/FinalVisacard
        [HttpGet]
        public ActionResult<IEnumerable<Finalvisacard>> GetAllVisacard()
        {
            return Ok(_finalVisacardService.GetAllVisacard());
        }

        // GET: api/FinalVisacard/5
        [HttpGet("{id}")]
        public ActionResult<Finalvisacard> GetVisacardById(int id)
        {
            var visacard = _finalVisacardService.GetVisacardById(id);

            if (visacard == null)
            {
                return NotFound();
            }

            return Ok(visacard);
        }

        // POST: api/FinalVisacard
        [HttpPost]
        public ActionResult CreateVisacard([FromBody] Finalvisacard finalVisacard)
        {
            _finalVisacardService.CreateVisacard(finalVisacard);
            return CreatedAtAction(nameof(GetVisacardById), new { id = finalVisacard.Visaid }, finalVisacard);
        }

        // PUT: api/FinalVisacard/5
        [HttpPut("{id}")]
        public ActionResult UpdateVisacard(int id, [FromBody] Finalvisacard finalVisacard)
        {
            if (id != finalVisacard.Visaid)
            {
                return BadRequest();
            }

            _finalVisacardService.UpdateVisacard(finalVisacard);
            return NoContent();
        }

        // DELETE: api/FinalVisacard/5
        [HttpDelete("{id}")]
        public ActionResult DeleteVisacard(int id)
        {
            var visacard = _finalVisacardService.GetVisacardById(id);
            if (visacard == null)
            {
                return NotFound();
            }

            _finalVisacardService.DeleteVisacard(id);
            return NoContent();
        }
    }
}
