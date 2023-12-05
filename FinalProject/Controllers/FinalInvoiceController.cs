using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using LearningHub.Core.Data;
using LearningHub.Infra.Services;

using System.Collections.Generic;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalInvoiceController : ControllerBase
    {
        private readonly IFinalInvoiceService _finalInvoiceService;

        public FinalInvoiceController(IFinalInvoiceService finalInvoiceService)
        {
            _finalInvoiceService = finalInvoiceService;
        }

        [HttpGet]
        public List<Finalinvoice> GetAllInvoices()
        {
            return _finalInvoiceService.GetAllInvoices();
        }

        [HttpGet]
        [Route("{invoiceId}")]
        public Finalinvoice FetchInvoiceById(decimal invoiceId)
        {
            return _finalInvoiceService.FetchInvoiceById(invoiceId);
        }

        [HttpPost]
        public void CreateInvoice(Finalinvoice invoice)
        {
            _finalInvoiceService.CreateInvoice(invoice);
        }

        [HttpPut]
        public void UpdateInvoice(Finalinvoice invoice)
        {
            _finalInvoiceService.UpdateInvoice(invoice);
        }

        [HttpDelete]
        [Route("{invoiceId}")]
        public void RemoveInvoice(decimal invoiceId)
        {
            _finalInvoiceService.RemoveInvoice(invoiceId);
        }

        [HttpGet]
        [Route("{invoiceId}/pdf")]
        public IActionResult GetInvoiceAsPDF(decimal invoiceId)
        {
            var invoice = _finalInvoiceService.FetchInvoiceById(invoiceId);
            if (invoice == null)
            {
                return NotFound("Invoice not found.");
            }

            byte[] pdfData = _finalInvoiceService.GeneratePDFInvoice(invoice);
            return File(pdfData, "application/pdf", $"Invoice_{invoiceId}.pdf");
        }


        // You can continue to expand this controller with other routes as needed for additional functionalities or operations.
    }
}
