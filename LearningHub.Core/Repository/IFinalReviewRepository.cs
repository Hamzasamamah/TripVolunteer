using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.Core.Data;
using System.Collections.Generic;

namespace LearningHub.Core.Repository
{
    public interface IFinalReviewRepository
    {
        List<Finalreview> GetAllReviews();
        void CreateReview(Finalreview review);
        void UpdateReview(Finalreview review);
        void DeleteReview(decimal reviewId);
        Finalreview GetReviewById(decimal reviewId);
    }
}
