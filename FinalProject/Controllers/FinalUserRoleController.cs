using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LearningHub.Core.Data;
using LearningHub.Infra.Services;
using LearningHub.Core.Services;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalUserRoleController : ControllerBase
    {
        private readonly IFinalUserRoleService _finalUserRoleService;

        public FinalUserRoleController(IFinalUserRoleService finalUserRoleService)
        {
            _finalUserRoleService = finalUserRoleService;
        }

        [HttpGet]
        public List<Finaluserrole> GetAllUserRoles()
        {
            return _finalUserRoleService.GetAllUserRoles();
        }

        [HttpGet]
        [Route("{roleId}")]
        public Finaluserrole GetUserRoleById(decimal roleId)
        {
            return _finalUserRoleService.GetUserRoleById(roleId);
        }

        [HttpPost]
        public IActionResult CreateUserRole(string roleName)
        {
            try
            {
                _finalUserRoleService.CreateUserRole(roleName);
                return Ok("Role created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{roleId}")]
        public IActionResult UpdateUserRole(decimal roleId, string roleName)
        {
            try
            {
                _finalUserRoleService.UpdateUserRole(roleId, roleName);
                return Ok("Role updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{roleId}")]
        public IActionResult DeleteUserRole(decimal roleId)
        {
            try
            {
                _finalUserRoleService.DeleteUserRole(roleId);
                return Ok("Role deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
