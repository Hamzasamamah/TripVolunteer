using LearningHub.Core.Data;
using LearningHub.Core.Services;
using LearningHub.Core.Repository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using System.Text;
using LearningHub.Core.DTO;

namespace LearningHub.Infra.Services
{
    public class FinalUserService : IFinalUserService
    {
        private readonly IFinalUserRepository UserRepository;  // <-- Change type to IFinalUserRepository

        public FinalUserService(IFinalUserRepository userRepository)  // <-- Change parameter type to IFinalUserRepository
        {
            this.UserRepository = userRepository;
        }

        public List<Finaluser> GetAllUsers()
        {
            return UserRepository.GetAllUsers();
        }

        public void CreateUser(Finaluser finaluser)
        {
            UserRepository.CreateUser(finaluser);
        }

        public void UpdateUser(Finaluser user)
        {
            UserRepository.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            UserRepository.DeleteUser(id);
        }

        public Finaluser GetUserById(int id)
        {
            return UserRepository.GetUserById(id);
        }


        public string Auth(Finaluser login)
        {
            var result = UserRepository.Auth(login);
            if (result == null)
            {
                return null;
            }
            else
            {
                var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("HelloTraineesinwebapicourse@34567"));
                var signin = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
                {
                    new Claim("Username", result.Username),
                    new Claim("RoleId", result.Roleid.ToString()),
                    new Claim("Userid", result.Userid.ToString()),
                    new Claim("Firstname", result.Fullname),
                    new Claim("Phonenumber", result.Phone),
                    new Claim("Email", result.Email),
                    new Claim("Imagename", result.Imagepath),


                };
                var tokenOptions = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddSeconds(60),
                    signingCredentials: signin);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return tokenString;
            }
        }


        public int GetNumUsers()
        {
            return UserRepository.GetNumUsers();
        }

        public List<Finaluser> GetAllAdmins()
        {
            return UserRepository.GetAllAdmins();
        }

        public List<UserWithTrips> GetAllUsersWithRole2()
        {
            // Here you can add any business logic, validations, transformations, etc.
            return UserRepository.GetAllUsersWithRole2();

        }
    }
}
