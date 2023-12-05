using Dapper;
using LearningHub.Core.Common;
using LearningHub.Core.Data;
using LearningHub.Core.DTO;
using LearningHub.Core.Repository;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace LearningHub.Infra.Repository
{

    public class FinalUserRepository : IFinalUserRepository
    {
        private readonly IDbContext _dbContext;

        public FinalUserRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        //Get All
        public List<Finaluser> GetAllUsers()
        {
            IEnumerable<Finaluser> result = _dbContext.Connection.Query<Finaluser>
                ("FINALUSERS_PACKAGE.GetAllUsers", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }



        //Create Review
        public void CreateUser(Finaluser finaluser)
        {
            var p = new DynamicParameters();
            p.Add("UName", finaluser.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PWD", finaluser.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("FName", finaluser.Fullname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ImgPath", finaluser.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Gen", finaluser.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Eml", finaluser.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Phn", finaluser.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("R_ID", finaluser.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("FINALUSERS_PACKAGE.Create_User", p,
                commandType: CommandType.StoredProcedure);
        }

        public void UpdateUser(Finaluser user)
        {
            var p = new DynamicParameters();
            p.Add("ID", user.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("UName", user.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PWD", user.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("FName", user.Fullname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ImgPath", user.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Gen", user.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Eml", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Phn", user.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("R_ID", user.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("FINALUSERS_PACKAGE.Update_User", p,
                commandType: CommandType.StoredProcedure);
        }
        //public void UpdateUser(Finaluser finaluser)
        //{
        //    var p = new DynamicParameters();
        //    p.Add("ID", finaluser.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //    p.Add("UName", finaluser.Username, dbType: DbType.String, direction: ParameterDirection.Input);
        //    p.Add("PWD", finaluser.Password, dbType: DbType.String, direction: ParameterDirection.Input);
        //    p.Add("FName", finaluser.Fullname, dbType: DbType.String, direction: ParameterDirection.Input);
        //    p.Add("ImgPath", finaluser.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
        //    p.Add("Gen", finaluser.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
        //    p.Add("Eml", finaluser.Email, dbType: DbType.String, direction: ParameterDirection.Input);
        //    p.Add("Phn", finaluser.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
        //    p.Add("R_ID", finaluser.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //    var result = _dbContext.Connection.Execute("FINALUSERS_PACKAGE.Update_User", p,
        //        commandType: CommandType.StoredProcedure);
        //}



        public void DeleteUser(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("FINALUSERS_PACKAGE.DeleteUser", p,
                commandType: CommandType.StoredProcedure);
        }

        public Finaluser GetUserById(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Finaluser>("FINALUSERS_PACKAGE.GetUserById",
                p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }


        public Finaluser Auth(Finaluser finaluser)
        {
            var p = new DynamicParameters();
            p.Add("User_NAME", finaluser.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PASS", finaluser.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Finaluser> result = _dbContext.Connection.Query<Finaluser>("FINALUSERS_PACKAGE.User_Login", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();



        }

        public int GetNumUsers()
        {
            IEnumerable<Finaluser> result = _dbContext.Connection.Query<Finaluser>
                ("FINALUSERS_PACKAGE.GetAllUsers", commandType: CommandType.StoredProcedure);
            return result.ToList().Count;
        }

        public List<Finaluser> GetAllAdmins()
        {
            IEnumerable<Finaluser> result = _dbContext.Connection.Query<Finaluser>
                ("FinalUsers_Package.getalluserswithrole1", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<UserWithTrips> GetAllUsersWithRole2()
        {
            IEnumerable<UserWithTrips> result = _dbContext.Connection.Query<UserWithTrips>(
                "FINALUSERS_PACKAGE.GetAllUsersWithRole2",
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }

    }

}
