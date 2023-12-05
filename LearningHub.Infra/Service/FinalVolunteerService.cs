using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using System.Collections.Generic;

namespace LearningHub.Infra.Services
{
    public class FinalVolunteerService : IFinalVolunteerService
    {
        private readonly IFinalVolunteerRepository _finalVolunteerRepository;

        public FinalVolunteerService(IFinalVolunteerRepository finalVolunteerRepository)
        {
            _finalVolunteerRepository = finalVolunteerRepository;
        }

        public List<Finalvolunteer> GetAllVolunteers()
        {
            return _finalVolunteerRepository.GetAllVolunteers();
        }

        public Finalvolunteer GetVolunteerById(decimal volunteerId)
        {
            return _finalVolunteerRepository.GetVolunteerById(volunteerId);
        }

        public void CreateVolunteer(Finalvolunteer volunteer)
        {
            // Add any additional business logic here (if necessary)
            _finalVolunteerRepository.CreateVolunteer(volunteer);
        }

        public void UpdateVolunteer(Finalvolunteer volunteer)
        {
            // Add any additional business logic here (if necessary)
            _finalVolunteerRepository.UpdateVolunteer(volunteer);
        }

        public void DeleteVolunteer(decimal volunteerId)
        {
            // Add any additional business logic here (if necessary)
            _finalVolunteerRepository.DeleteVolunteer(volunteerId);
        }
    }
}
