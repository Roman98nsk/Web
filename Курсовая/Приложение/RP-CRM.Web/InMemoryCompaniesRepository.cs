using System;
using System.Collections.Generic;
using System.Linq;
using RP_CRM.Data;

namespace RP_CRM.Web
{
    public interface IInMemoryCompaniesRepository
    {
        IEnumerable<Company> GetAllCompanies();
        void ConcludeContract(string companyName);
        void VoidContract(string companyName);
    }
    
    public class InMemoryCompaniesRepository : IInMemoryCompaniesRepository
    {
        private IEnumerable<Company> _companies;

        public InMemoryCompaniesRepository()
        {
            _companies = new List<string>()
                {
                    "Сбербанк", "Яндекс", "Luxoft"
                }
                .Select(companyName => new Company(companyName));
        }

        public IEnumerable<Company> GetAllCompanies() => _companies;

        public void ConcludeContract(string companyName)
        {
            _companies
                .First(company => company.Name == companyName)
                .ContractStatus = ContractStatus.Concluded;
        }
        public void VoidContract(string companyName)
        {
            _companies
                .First(company => company.Name == companyName)
                .ContractStatus = ContractStatus.Voided;
        }

    }
}