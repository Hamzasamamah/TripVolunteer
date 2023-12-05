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
    public class FinalHomeService : IFinalHomeService
    {
        private readonly IFinalHomeRepository _finalHomeRepository;

        public FinalHomeService(IFinalHomeRepository finalHomeRepository)
        {
            _finalHomeRepository = finalHomeRepository;
        }

        public void InsertHome(string paragraph)
        {
            // You can add any business logic if required before inserting
            _finalHomeRepository.InsertHome(paragraph);
        }

        public List<Finalhome> GetAllHomes()
        {
            return _finalHomeRepository.GetAllHomes();
        }

        public void UpdateHome(decimal homeId, string paragraph)
        {
            // Any additional business logic before updating a home entry
            _finalHomeRepository.UpdateHome(homeId, paragraph);
        }

        public void DeleteHome(decimal homeId)
        {
            // Any additional business logic before deleting a home entry
            _finalHomeRepository.DeleteHome(homeId);
        }

        public Finalhome GetHomeById(decimal homeId)
        {
            return _finalHomeRepository.GetHomeById(homeId);
        }
    }
}
