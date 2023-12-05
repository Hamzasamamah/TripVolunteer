using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using LearningHub.Core.Data;

namespace LearningHub.Core.Repository
{
    public interface IFinalPaymentRepository
    {
        public List<Finalpayment> GetAllPayment();
        public void CreatePayment(Finalpayment finalpayment);
        public void UpdatePayment(Finalpayment finalpayment);
        public void DeletePayment(int id);
        public Finalcategory GetPaymentById(int id);
    }
}
