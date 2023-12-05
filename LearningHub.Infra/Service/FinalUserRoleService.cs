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
    public class FinalUserRoleService : IFinalUserRoleService
    {
        private readonly IFinalUserRoleRepository _finalUserRoleRepository;

        public FinalUserRoleService(IFinalUserRoleRepository finalUserRoleRepository)
        {
            _finalUserRoleRepository = finalUserRoleRepository;
        }

        public void CreateUserRole(string roleName)
        {
            // Additional business logic before creating a user role can go here
            _finalUserRoleRepository.CreateUserRole(roleName);
        }

        public List<Finaluserrole> GetAllUserRoles()
        {
            return _finalUserRoleRepository.GetAllUserRoles();
        }

        public Finaluserrole GetUserRoleById(decimal roleId)
        {
            return _finalUserRoleRepository.GetUserRoleById(roleId);
        }

        public void UpdateUserRole(decimal roleId, string roleName)
        {
            // Additional business logic before updating a user role can go here
            _finalUserRoleRepository.UpdateUserRole(roleId, roleName);
        }

        public void DeleteUserRole(decimal roleId)
        {
            // Additional business logic before deleting a user role can go here
            _finalUserRoleRepository.DeleteUserRole(roleId);
        }
    }
}
