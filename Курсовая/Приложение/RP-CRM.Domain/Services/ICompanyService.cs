using System.Collections.Generic;
using RP_CRM.Data;

namespace RP_CRM.Domain.Services
{
    public interface ICompanyService : IGenericService<Company>
    {
        IEnumerable<Company> GetCompaniesWithConcludedContract();
        IEnumerable<Company> GetCompaniesWithNotConcludedContract();
        IEnumerable<Company> GetCompaniesWithVoidedContract();
    }
}