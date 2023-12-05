using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Repository
{
    public interface IFinalInvoiceRepository
    {
        void AddInvoice(Finalinvoice invoice);
        List<Finalinvoice> RetrieveAllInvoices();
        void ModifyInvoice(Finalinvoice invoice);
        void RemoveInvoice(decimal invoiceId);
        Finalinvoice FetchInvoiceById(decimal invoiceId);
    }
}
