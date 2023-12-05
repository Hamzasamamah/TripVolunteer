using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using LearningHub.Core.Data;

namespace LearningHub.Core.Repository
{
    public interface IFinalUserRoleRepository
    {
        void CreateUserRole(string roleName);
        List<Finaluserrole> GetAllUserRoles();
        Finaluserrole GetUserRoleById(decimal roleId);
        void UpdateUserRole(decimal roleId, string roleName);
        void DeleteUserRole(decimal roleId);
    }
}
