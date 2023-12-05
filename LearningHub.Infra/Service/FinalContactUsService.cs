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
    public class FinalContactUsService : IFinalContactUsService
    {
        private readonly IFinalContactUsRepository _finalContactUsRepository;

        public FinalContactUsService(IFinalContactUsRepository finalContactUsRepository)
        {
            _finalContactUsRepository = finalContactUsRepository;
        }

        public void AddContact(Finalcontactu contact)
        {
            // You can add any business logic if required before inserting
            _finalContactUsRepository.AddContact(contact);
        }

        public List<Finalcontactu> RetrieveAllContacts()
        {
            return _finalContactUsRepository.RetrieveAllContacts();
        }

        public void ModifyContact(Finalcontactu contact)
        {
            // Any additional business logic before updating an entry
            _finalContactUsRepository.ModifyContact(contact);
        }

        public void RemoveContact(decimal contactUsId)
        {
            // Any additional business logic before deleting an entry
            _finalContactUsRepository.RemoveContact(contactUsId);
        }

        public Finalcontactu FetchContactById(decimal contactUsId)
        {
            return _finalContactUsRepository.FetchContactById(contactUsId);
        }
    }
}
