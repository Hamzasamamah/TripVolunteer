using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using LearningHub.Core.Data;

namespace LearningHub.Core.Services
{
    public interface IFinalReviewService
    {
        public List<Finalreview> GetAllReview();
        public void CreateReview(Finalreview finalreview);
        public void UpdateReview(Finalreview finalreview);
        public void DeleteReview(int id);
        public Finalreview GetReviewById(int id);
    }
}
