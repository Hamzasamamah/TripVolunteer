using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using LearningHub.Core.Services;

namespace LearningHub.Infra.Services
{
    public class FinalTestimonialService : IFinalTestimonialService
    {
        private readonly IFinalTestimonialRepository _finalTestimonialRepository;

        public FinalTestimonialService(IFinalTestimonialRepository finalTestimonialRepository)
        {
            _finalTestimonialRepository = finalTestimonialRepository;
        }

        public void CreateTestimonial(decimal userId, decimal tripId, string message, string status)
        {
            // Any additional business logic before creating a testimonial
            _finalTestimonialRepository.CreateTestimonial(userId, tripId, message, status);
        }

        public List<Finaltestimonial> GetAllTestimonials()
        {
            return _finalTestimonialRepository.GetAllTestimonials();
        }

        public Finaltestimonial GetTestimonialById(decimal testimonialId)
        {
            return _finalTestimonialRepository.GetTestimonialById(testimonialId);
        }

        public void UpdateTestimonial(decimal testimonialId, string message, string status)
        {
            // Any additional business logic before updating a testimonial
            _finalTestimonialRepository.UpdateTestimonial(testimonialId, message, status);
        }
       


        public void DeleteTestimonial(decimal testimonialId)
        {
            // Any additional business logic before deleting a testimonial
            _finalTestimonialRepository.DeleteTestimonial(testimonialId);
        }
        public void UpdateStatus(decimal testimonialId)
        {
            _finalTestimonialRepository.UpdateStatus(testimonialId);
        }

    }
}
