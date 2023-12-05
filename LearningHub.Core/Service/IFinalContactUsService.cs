using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using LearningHub.Core.Data;

namespace LearningHub.Core.Services
{
    public interface IFinalContactUsService
    {
        void AddContact(Finalcontactu contact);
        List<Finalcontactu> RetrieveAllContacts();
        void ModifyContact(Finalcontactu contact);
        void RemoveContact(decimal contactUsId);
        Finalcontactu FetchContactById(decimal contactUsId);
    }
}
