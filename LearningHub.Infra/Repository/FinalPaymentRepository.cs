using Dapper;
using LearningHub.Core.Common;
using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LearningHub.Infra.Repository
{
    public class FinalPaymentRepository : IFinalPaymentRepository
    {
        private readonly IDbContext _dbContext;

        public FinalPaymentRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Finalpayment> GetAllPayment()
        {
            IEnumerable<Finalpayment> result = _dbContext.Connection.Query<Finalpayment>
                ("PAYMENT_PACKAGE.GetAllPayment", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public void CreatePayment(Finalpayment finalpayment)
        {
            var p = new DynamicParameters();
            p.Add("UID", finalpayment.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("TID", finalpayment.Tripid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Payamount", finalpayment.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Paydate", finalpayment.Paymentdate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("Invoid", finalpayment.Invoiceid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("PAYMENT_PACKAGE.CreatePayment", p,
                commandType: CommandType.StoredProcedure);
        }


        public void UpdatePayment(Finalpayment finalpayment)
        {
            var p = new DynamicParameters();
            p.Add("ID", finalpayment.Paymentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("UID", finalpayment.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("TID", finalpayment.Tripid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Payamount", finalpayment.Paymentamount, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Paydate", finalpayment.Paymentdate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("Invoid", finalpayment.Invoiceid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("PAYMENT_PACKAGE.UpdatePayment", p,
                commandType: CommandType.StoredProcedure);
        }



        public void DeletePayment(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("PAYMENT_PACKAGE.DeletePayment", p,
                commandType: CommandType.StoredProcedure);
        }

        public Finalcategory GetPaymentById(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Finalcategory>("PAYMENT_PACKAGE.GetPaymentById",
                p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }


    }

}
