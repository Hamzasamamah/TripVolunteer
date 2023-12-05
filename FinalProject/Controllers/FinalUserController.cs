using Microsoft.AspNetCore.Mvc;
using LearningHub.Core.Data;
using LearningHub.Core.Services;
using System.Collections.Generic;
using LearningHub.Core.DTO;

namespace LearningHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalUserController : ControllerBase
    {
        private readonly IFinalUserService _finalUserService;

        public FinalUserController(IFinalUserService finalUserService)
        {
            _finalUserService = finalUserService;
        }

        // GET: api/FinalUser
        [HttpGet]
        public ActionResult<IEnumerable<Finaluser>> GetAllUsers()
        {
            return Ok(_finalUserService.GetAllUsers());
        }

        // GET: api/FinalUser/5
        [HttpGet("{id}")]
        public ActionResult<Finaluser> GetUserById(int id)
        {
            var user = _finalUserService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: api/FinalUser
        [HttpPost]
        public ActionResult CreateUser([FromBody] Finaluser finalUser)
        {
            _finalUserService.CreateUser(finalUser);
            return CreatedAtAction(nameof(GetUserById), new { id = finalUser.Userid }, finalUser);
        }

        // PUT: api/FinalUser/5
        //[HttpPut("{id}")]
        //public ActionResult UpdateUser(int id, [FromBody] Finaluser finalUser)
        //{
        //    if (id != finalUser.Userid)
        //    {
        //        return BadRequest();
        //    }

        //    _finalUserService.UpdateUser(finalUser);
        //    return NoContent();
        //}

        // DELETE: api/FinalUser/5
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var user = _finalUserService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            _finalUserService.DeleteUser(id);
            return NoContent();
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Auth( [FromBody] Finaluser  finaluser)
        {
            try
            {
                var token = _finalUserService.Auth(finaluser);
                if (token == null)
                {
                    return Unauthorized("Invalid user credentials");
                }

                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        

        [HttpGet]
        [Route("num")]
        public ActionResult<int> GetNumUsers()
        {
            int userCount = _finalUserService.GetNumUsers();
            return Ok(userCount);
        }
        [Route("uploadImage")]
        [HttpPost]
        public Finaluser UploadIMage()
        {

            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\DELL\\OneDrive\\Desktop\\obidah\\FinalProject\\FinalProject\\src\\assets\\admin\\images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Finaluser item = new Finaluser();
            item.Imagepath = fileName;
            return item;
        }

        [HttpPut]
        public void UpdateUser(Finaluser finalUser)
        {


            _finalUserService.UpdateUser(finalUser);

        }

        [HttpGet]
        [Route("Admins")]
        public ActionResult<IEnumerable<Finaluser>> GetAllAdmins()
        {
            return Ok(_finalUserService.GetAllAdmins());
        }

        [HttpGet]
        [Route("UsersOnly")]

        public ActionResult<List<UserWithTrips>> GetAllUsersWithRole2()
        {
            var users = _finalUserService.GetAllUsersWithRole2();

            if (users == null || users.Count == 0)
            {
                return NotFound("No users found with RoleID = 2.");
            }

            return Ok(users);
        }

    }
}
