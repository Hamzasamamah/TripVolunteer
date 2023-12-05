using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Repository
{
    public interface IFinalVolunteerRepository
    {
        List<Finalvolunteer> GetAllVolunteers();
        Finalvolunteer GetVolunteerById(decimal volunteerId);
        void CreateVolunteer(Finalvolunteer volunteer);
        void UpdateVolunteer(Finalvolunteer volunteer);
        void DeleteVolunteer(decimal volunteerId);
    }
}
