using System;

namespace RP_CRM.Data
{
    public class Company : BaseEntity
    {
        public ContractStatus ContractStatus { get; set; }

        public Company(string companyName)
        {
            Id = Guid.NewGuid();
            Name = companyName;
            ContractStatus = ContractStatus.NotConcluded;
        }
    }
}