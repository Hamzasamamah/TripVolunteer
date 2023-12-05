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
    public class FinalAboutUsService : IFinalAboutUsService
    {
        private readonly IFinalAboutUsRepository _finalAboutUsRepository;

        public FinalAboutUsService(IFinalAboutUsRepository finalAboutUsRepository)
        {
            _finalAboutUsRepository = finalAboutUsRepository;
        }

        public void InsertAbout(string paragraph, decimal homeId)
        {
            // You can add any business logic if required before inserting
            _finalAboutUsRepository.InsertAbout(paragraph, homeId);
        }

        public List<Finalaboutu> GetAllAbout()
        {
            return _finalAboutUsRepository.GetAllAbout();
        }

        public void UpdateAbout(decimal aboutUsId, string paragraph, decimal homeId)
        {
            // Any additional business logic before updating an entry
            _finalAboutUsRepository.UpdateAbout(aboutUsId, paragraph, homeId);
        }

        public void DeleteAbout(decimal aboutUsId)
        {
            // Any additional business logic before deleting an entry
            _finalAboutUsRepository.DeleteAbout(aboutUsId);
        }

        public Finalaboutu GetAboutById(decimal aboutUsId)
        {
            return _finalAboutUsRepository.GetAboutById(aboutUsId);
        }
    }
}
