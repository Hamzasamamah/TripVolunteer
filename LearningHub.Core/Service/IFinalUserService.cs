using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using LearningHub.Core.Data;
using LearningHub.Core.DTO;

namespace LearningHub.Core.Services
{
    public interface IFinalUserService
    {
        public List<Finaluser> GetAllUsers();
        public void CreateUser(Finaluser finaluser);
        public void DeleteUser(int id);
        public Finaluser GetUserById(int id);
        public String Auth(Finaluser finaluser);

        public int GetNumUsers();
        public void UpdateUser(Finaluser user);

        public List<Finaluser> GetAllAdmins();
        List<UserWithTrips> GetAllUsersWithRole2();
    }
}
