using System.Collections.Generic;
using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using LearningHub.Core.Services;

namespace LearningHub.Infra.Services
{
    public class FinalReviewService : IFinalReviewService
    {
        private readonly IFinalReviewRepository ReviewRepository;  // <-- Change type to IFinalReviewRepository

        public FinalReviewService(IFinalReviewRepository reviewRepository)  // <-- Change parameter type to IFinalReviewRepository
        {
            this.ReviewRepository = reviewRepository;
        }

        public List<Finalreview> GetAllReview()
        {
            return ReviewRepository.GetAllReviews();  // Adjusted method name
        }

        public void CreateReview(Finalreview finalreview)
        {
            ReviewRepository.CreateReview(finalreview);
        }

        public void UpdateReview(Finalreview finalreview)
        {
            ReviewRepository.UpdateReview(finalreview);
        }

        public void DeleteReview(int id)
        {
            ReviewRepository.DeleteReview(id);
        }

        public Finalreview GetReviewById(int id)
        {
            return ReviewRepository.GetReviewById(id);
        }
    }
}
