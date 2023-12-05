using LearningHub.Core.Data;
using LearningHub.Core.Services;
using LearningHub.Core.Repository;

namespace LearningHub.Infra.Services
{
    public class FinalVisacardService : IFinalVisacardService
    {
        private readonly IFinalVisacardRepository VisacardRepository;  // <-- Change type to IFinalVisacardRepository

        public FinalVisacardService(IFinalVisacardRepository visacardRepository)  // <-- Change parameter type to IFinalVisacardRepository
        {
            this.VisacardRepository = visacardRepository;
        }

        public List<Finalvisacard> GetAllVisacard()
        {
            return VisacardRepository.GetAllVisacard();
        }

        public void CreateVisacard(Finalvisacard finalvisacard)
        {
            VisacardRepository.CreateVisacard(finalvisacard);
        }

        public void UpdateVisacard(Finalvisacard finalvisacard)
        {
            VisacardRepository.UpdateVisacard(finalvisacard);
        }

        public void DeleteVisacard(int id)
        {
            VisacardRepository.DeleteVisacard(id);
        }

        public Finalvisacard GetVisacardById(int id)
        {
            return VisacardRepository.GetVisacardById(id);
        }
    }
}
