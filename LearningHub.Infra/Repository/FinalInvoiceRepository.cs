using Dapper;
using LearningHub.Core.Common;
using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LearningHub.Infra.Repository
{
    public class FinalInvoiceRepository : IFinalInvoiceRepository
    {
        private readonly IDbContext _dbContext;

        public FinalInvoiceRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddInvoice(Finalinvoice invoice)
        {
            var p = new DynamicParameters();
            p.Add("u_id", invoice.Userid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("t_id", invoice.Tripid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("inv_amt", invoice.Amount, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("inv_content", invoice.Invoicecontent, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("inv_timestamp", invoice.Timestamp, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("FinalInvoices_Package.AddInvoice", p, commandType: CommandType.StoredProcedure);
        }

        public List<Finalinvoice> RetrieveAllInvoices()
        {
            IEnumerable<Finalinvoice> result = _dbContext.Connection.Query<Finalinvoice>(
                "FinalInvoices_Package.RetrieveAllInvoices",
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }

        public void ModifyInvoice(Finalinvoice invoice)
        {
            var p = new DynamicParameters();
            p.Add("inv_id", invoice.Invoiceid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("u_id", invoice.Userid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("t_id", invoice.Tripid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("inv_amt", invoice.Amount, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("inv_content", invoice.Invoicecontent, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("inv_timestamp", invoice.Timestamp, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("FinalInvoices_Package.ModifyInvoice", p, commandType: CommandType.StoredProcedure);
        }

        public void RemoveInvoice(decimal invoiceId)
        {
            var p = new DynamicParameters();
            p.Add("inv_id", invoiceId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("FinalInvoices_Package.RemoveInvoice", p, commandType: CommandType.StoredProcedure);
        }

        public Finalinvoice FetchInvoiceById(decimal invoiceId)
        {
            var p = new DynamicParameters();
            p.Add("inv_id", invoiceId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<Finalinvoice> result = _dbContext.Connection.Query<Finalinvoice>(
                "FinalInvoices_Package.FetchInvoiceById",
                p,
                commandType: CommandType.StoredProcedure
            );

            return result.FirstOrDefault();
        }
    }
}
