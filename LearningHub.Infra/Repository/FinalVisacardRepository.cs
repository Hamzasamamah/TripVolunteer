using Dapper;
using LearningHub.Core.Common;
using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LearningHub.Infra.Repository
{
    public class FinalVisacardRepository : IFinalVisacardRepository
    {
        private readonly IDbContext _dbContext;

        public FinalVisacardRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get All
        public List<Finalvisacard> GetAllVisacard()
        {
            IEnumerable<Finalvisacard> result = _dbContext.Connection.Query<Finalvisacard>
                ("VISACARD_PACKAGE.GetAllVisacard", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }



        //Create Review
        public void CreateVisacard(Finalvisacard finalvisacard)
        {
            var p = new DynamicParameters();
            p.Add("Cardnum", finalvisacard.Cardnumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CardCvv", finalvisacard.Cvv, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CardAmount", finalvisacard.Amount, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("CardHold", finalvisacard.Holdname, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("VISACARD_PACKAGE.CreateVisacard", p,
                commandType: CommandType.StoredProcedure);
        }


        public void UpdateVisacard(Finalvisacard finalvisacard)
        {
            var p = new DynamicParameters();
            p.Add("ID", finalvisacard.Visaid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Cardnum", finalvisacard.Cardnumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CardCvv", finalvisacard.Cvv, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CardAmount", finalvisacard.Amount, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("CardHold", finalvisacard.Holdname, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("VISACARD_PACKAGE.UpdateVisacard", p,
                commandType: CommandType.StoredProcedure);
        }



        public void DeleteVisacard(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("VISACARD_PACKAGE.DeleteVisacard", p,
                commandType: CommandType.StoredProcedure);
        }

        public Finalvisacard GetVisacardById(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Finalvisacard>("VISACARD_PACKAGE.GetVisacardById",
                p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }




    }
}
