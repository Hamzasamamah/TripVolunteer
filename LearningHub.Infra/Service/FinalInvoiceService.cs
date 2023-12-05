using DinkToPdf;
using DinkToPdf.Contracts;
using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using ColorMode = DinkToPdf.ColorMode;
using PaperKind = DinkToPdf.PaperKind;
using System.IO;


namespace LearningHub.Infra.Services
{
    public class FinalInvoiceService : IFinalInvoiceService
    {
        private readonly IFinalInvoiceRepository _finalInvoiceRepository;
        private readonly IConverter _pdfConverter;

        public FinalInvoiceService(IFinalInvoiceRepository finalInvoiceRepository, DinkToPdf.Contracts.IConverter pdfConverter)
        {
            _finalInvoiceRepository = finalInvoiceRepository;
            _pdfConverter = pdfConverter;

            string pathToDllDirectory = "C:\\Users\\User\\Desktop\\FinalProject\\FinalProject\\bin\\Debug\\net6.0\\runtimes\\win-x86\\native";
            Environment.SetEnvironmentVariable("PATH", pathToDllDirectory + ";" + Environment.GetEnvironmentVariable("PATH"));
        }


        public byte[] GeneratePDFInvoice(Finalinvoice invoice)
        {
          
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = { ColorMode = ColorMode.Color, Orientation = Orientation.Portrait, PaperSize = PaperKind.A4 },
                Objects = { new ObjectSettings() { HtmlContent = invoice.Invoicecontent } }
            };
            return _pdfConverter.Convert(doc);
        }

        public List<Finalinvoice> GetAllInvoices()
        {
            return _finalInvoiceRepository.RetrieveAllInvoices();
        }

        public void CreateInvoice(Finalinvoice invoice)
        {
            // Any additional business logic before creating an invoice
            _finalInvoiceRepository.AddInvoice(invoice);
        }

        public void UpdateInvoice(Finalinvoice invoice)
        {
            // Any additional business logic before updating an invoice
            _finalInvoiceRepository.ModifyInvoice(invoice);
        }

        public void RemoveInvoice(decimal invoiceId)
        {
            // Any additional business logic before removing an invoice
            _finalInvoiceRepository.RemoveInvoice(invoiceId);
        }

        public Finalinvoice FetchInvoiceById(decimal invoiceId)
        {
            return _finalInvoiceRepository.FetchInvoiceById(invoiceId);
        }
    }
}
