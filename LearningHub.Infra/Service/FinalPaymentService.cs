using LearningHub.Core.Data;
using LearningHub.Core.Services;
using LearningHub.Core.Repository;

namespace LearningHub.Infra.Services
{
    public class FinalPaymentService : IFinalPaymentService
    {
        private readonly IFinalPaymentRepository PaymentRepository;  // <-- Change type to IFinalPaymentRepository

        public FinalPaymentService(IFinalPaymentRepository paymentRepository)  // <-- Change parameter type to IFinalPaymentRepository
        {
            this.PaymentRepository = paymentRepository;
        }

        public List<Finalpayment> GetAllPayment()
        {
            return PaymentRepository.GetAllPayment();  // Adjusted method name if needed
        }

        public void CreatePayment(Finalpayment finalpayment)
        {
            PaymentRepository.CreatePayment(finalpayment);
        }

        public void UpdatePayment(Finalpayment finalpayment)
        {
            PaymentRepository.UpdatePayment(finalpayment);
        }

        public void DeletePayment(int id)
        {
            PaymentRepository.DeletePayment(id);
        }

        public Finalcategory GetPaymentById(int id)
        {
            return PaymentRepository.GetPaymentById(id);  // Ensure the return type is Finalpayment and not Finalcategory
        }
    }
}
