using Dapper;
using LearningHub.Core.Common;
using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LearningHub.Infra.Repository
{
    public class FinalContactUsRepository : IFinalContactUsRepository
    {
        private readonly IDbContext _dbContext;

        public FinalContactUsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddContact(Finalcontactu contact)
        {
            var p = new DynamicParameters();
            p.Add("p_content", contact.Paragraph, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("h_ref_id", contact.HOME_ID, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("p_num", contact.phone_num, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_email", contact.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("FinalContactUs_Package.AddContact", p, commandType: CommandType.StoredProcedure);
        }

        public List<Finalcontactu> RetrieveAllContacts()
        {
            IEnumerable<Finalcontactu> result = _dbContext.Connection.Query<Finalcontactu>(
                "FinalContactUs_Package.RetrieveAllContacts",
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }

        public void ModifyContact(Finalcontactu contact)
        {
            var p = new DynamicParameters();
            p.Add("c_id", contact.CONTACT_US_ID, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("p_content", contact.Paragraph, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("h_ref_id", contact.HOME_ID, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("p_num", contact.phone_num, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_email", contact.Email, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("FinalContactUs_Package.ModifyContact", p, commandType: CommandType.StoredProcedure);
        }

        public void RemoveContact(decimal contactUsId)
        {
            var p = new DynamicParameters();
            p.Add("c_id", contactUsId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("FinalContactUs_Package.RemoveContact", p, commandType: CommandType.StoredProcedure);
        }

        public Finalcontactu FetchContactById(decimal contactUsId)
        {
            var p = new DynamicParameters();
            p.Add("c_id", contactUsId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<Finalcontactu> result = _dbContext.Connection.Query<Finalcontactu>(
                "FinalContactUs_Package.FetchContactById",
                p,
                commandType: CommandType.StoredProcedure
            );

            return result.FirstOrDefault();
        }
    }
}
