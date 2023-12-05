using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using LearningHub.Core.Data;

namespace LearningHub.Core.Repository
{
    public interface IFinalTestimonialRepository
    {
        void CreateTestimonial(decimal userId, decimal tripId, string message, string status);
        List<Finaltestimonial> GetAllTestimonials();
        Finaltestimonial GetTestimonialById(decimal testimonialId);
        void UpdateTestimonial(decimal testimonialId, string message, string status);
        void DeleteTestimonial(decimal testimonialId);
        void UpdateStatus(decimal testimonialId);

    }

}
