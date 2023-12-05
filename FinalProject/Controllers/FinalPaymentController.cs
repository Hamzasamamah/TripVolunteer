using Microsoft.AspNetCore.Mvc;
using LearningHub.Core.Data;
using LearningHub.Core.Services;
using System.Collections.Generic;

namespace LearningHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalPaymentController : ControllerBase
    {
        private readonly IFinalPaymentService _finalPaymentService;

        public FinalPaymentController(IFinalPaymentService finalPaymentService)
        {
            _finalPaymentService = finalPaymentService;
        }

        // GET: api/FinalPayment
        [HttpGet]
        public ActionResult<IEnumerable<Finalpayment>> GetAllPayments()
        {
            return Ok(_finalPaymentService.GetAllPayment());
        }

        // GET: api/FinalPayment/5
        [HttpGet("{id}")]
        public ActionResult<Finalpayment> GetPaymentById(int id)
        {
            var payment = _finalPaymentService.GetPaymentById(id);

            if (payment == null)
            {
                return NotFound();
            }

            return Ok(payment);
        }

        // POST: api/FinalPayment
        [HttpPost]
        public ActionResult CreatePayment([FromBody] Finalpayment finalPayment)
        {
            _finalPaymentService.CreatePayment(finalPayment);
            return CreatedAtAction(nameof(GetPaymentById), new { id = finalPayment.Paymentid }, finalPayment);
        }

        // PUT: api/FinalPayment/5
        [HttpPut("{id}")]
        public ActionResult UpdatePayment(int id, [FromBody] Finalpayment finalPayment)
        {
            if (id != finalPayment.Paymentid)
            {
                return BadRequest();
            }

            _finalPaymentService.UpdatePayment(finalPayment);
            return NoContent();
        }

        // DELETE: api/FinalPayment/5
        [HttpDelete("{id}")]
        public ActionResult DeletePayment(int id)
        {
            var payment = _finalPaymentService.GetPaymentById(id);
            if (payment == null)
            {
                return NotFound();
            }

            _finalPaymentService.DeletePayment(id);
            return NoContent();
        }
    }
}
