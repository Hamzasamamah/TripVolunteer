using Microsoft.AspNetCore.Mvc;
using LearningHub.Core.Data;
using LearningHub.Core.Services;
using System.Collections.Generic;

namespace LearningHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalReviewController : ControllerBase
    {
        private readonly IFinalReviewService _finalReviewService;

        public FinalReviewController(IFinalReviewService finalReviewService)
        {
            _finalReviewService = finalReviewService;
        }

        // GET: api/FinalReview
        [HttpGet]
        public ActionResult<IEnumerable<Finalreview>> GetAllReviews()
        {
            return Ok(_finalReviewService.GetAllReview());
        }

        // GET: api/FinalReview/5
        [HttpGet("{id}")]
        public ActionResult<Finalreview> GetReviewById(int id)
        {
            var review = _finalReviewService.GetReviewById(id);

            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        // POST: api/FinalReview
        [HttpPost]
        public ActionResult CreateReview([FromBody] Finalreview finalReview)
        {
            _finalReviewService.CreateReview(finalReview);
            return CreatedAtAction(nameof(GetReviewById), new { id = finalReview.Reviewid }, finalReview);
        }

        // PUT: api/FinalReview/5
        [HttpPut("{id}")]
        public ActionResult UpdateReview(int id, [FromBody] Finalreview finalReview)
        {
            if (id != finalReview.Reviewid)
            {
                return BadRequest();
            }

            _finalReviewService.UpdateReview(finalReview);
            return NoContent();
        }

        // DELETE: api/FinalReview/5
        [HttpDelete("{id}")]
        public ActionResult DeleteReview(int id)
        {
            var review = _finalReviewService.GetReviewById(id);
            if (review == null)
            {
                return NotFound();
            }

            _finalReviewService.DeleteReview(id);
            return NoContent();
        }
    }
}
