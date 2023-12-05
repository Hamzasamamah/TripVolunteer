using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.Core.Data;
using System.Collections.Generic;

namespace LearningHub.Infra.Services
{
    public interface IFinalVolunteerService
    {
        List<Finalvolunteer> GetAllVolunteers();
        Finalvolunteer GetVolunteerById(decimal volunteerId);
        void CreateVolunteer(Finalvolunteer volunteer);
        void UpdateVolunteer(Finalvolunteer volunteer);
        void DeleteVolunteer(decimal volunteerId);
    }
}
