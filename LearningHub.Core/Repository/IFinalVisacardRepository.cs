using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Repository
{
    public interface IFinalVisacardRepository
    {
        public List<Finalvisacard> GetAllVisacard();
        public void CreateVisacard(Finalvisacard finalvisacard);
        public void UpdateVisacard(Finalvisacard finalvisacard);
        public void DeleteVisacard(int id);
        public Finalvisacard GetVisacardById(int id);

    }
}
