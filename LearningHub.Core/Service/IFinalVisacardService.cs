using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using LearningHub.Core.Data;

namespace LearningHub.Core.Services
{
    public interface IFinalVisacardService
    {
        public List<Finalvisacard> GetAllVisacard();
        public void CreateVisacard(Finalvisacard finalvisacard);
        public void UpdateVisacard(Finalvisacard finalvisacard);
        public void DeleteVisacard(int id);
        public Finalvisacard GetVisacardById(int id);
    }
}
