using LearningHub.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningHub.Infra.Services
{
    public interface IFinalInvoiceService
    {
        List<Finalinvoice> GetAllInvoices();
        void CreateInvoice(Finalinvoice invoice);
        void UpdateInvoice(Finalinvoice invoice);
        void RemoveInvoice(decimal invoiceId);
        Finalinvoice FetchInvoiceById(decimal invoiceId);

        // Add this line for the GeneratePDFInvoice method
        byte[] GeneratePDFInvoice(Finalinvoice invoice);
    }
}
