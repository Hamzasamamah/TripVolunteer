using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using LearningHub.Core.Data;

namespace LearningHub.Core.Repository
{
    public interface IFinalHomeRepository
    {
        void InsertHome(string paragraph);
        List<Finalhome> GetAllHomes();
        void UpdateHome(decimal homeId, string paragraph);
        void DeleteHome(decimal homeId);
        Finalhome GetHomeById(decimal homeId);
    }
}
