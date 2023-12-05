using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace LearningHub.Core.Repository
{
    public interface IFinalAboutUsRepository
    {
        void InsertAbout(string paragraph, decimal homeId);
        List<Finalaboutu> GetAllAbout();
        void UpdateAbout(decimal aboutUsId, string paragraph, decimal homeId);
        void DeleteAbout(decimal aboutUsId);
        Finalaboutu GetAboutById(decimal aboutUsId);
    }
}
