using LearningHub.Core.Data;
using LearningHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Repository
{
    public interface IFinalUserRepository
    {
        public List<Finaluser> GetAllUsers();
        public void CreateUser(Finaluser finaluser);
        public void DeleteUser(int id);
        public Finaluser GetUserById(int id);
        public Finaluser Auth(Finaluser finaluser);
        public int GetNumUsers();
        public void UpdateUser(Finaluser user);
        public List<Finaluser> GetAllAdmins();
        List<UserWithTrips> GetAllUsersWithRole2();

    }
}
