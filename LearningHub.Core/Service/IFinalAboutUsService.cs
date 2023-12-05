using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using LearningHub.Core.Data;

namespace LearningHub.Core.Services
{
    public interface IFinalAboutUsService
    {
        void InsertAbout(string paragraph, decimal homeId);
        List<Finalaboutu> GetAllAbout();
        void UpdateAbout(decimal aboutUsId, string paragraph, decimal homeId);
        void DeleteAbout(decimal aboutUsId);
        Finalaboutu GetAboutById(decimal aboutUsId);
    }
}
