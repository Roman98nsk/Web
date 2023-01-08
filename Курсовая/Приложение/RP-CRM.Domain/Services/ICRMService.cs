using System;
using System.Collections.Generic;
using RP_CRM.Data;

namespace RP_CRM.Domain.Services
{
    public interface ICRMService
    {
        #region Domain specific methods

        void AddUserToCompany(Guid userId);
        void RemoveUserFromCompany(Guid userId);

        void ConcludeContractWithCompany(Guid companyId);
        void VoidContractWithCompany(Guid companyId);

        #endregion
    }
}