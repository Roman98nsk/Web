using System;
using System.Collections.Generic;
using RP_CRM.Data;

namespace RP_CRM.Domain.Services
{
    public interface IGenericService<T> where T : BaseEntity
    {
        void CreateOne(string name);
        IEnumerable<T> GetAllItems();
        IEnumerable<T> SearchItemsByNamePattern(string namePattern);
        void UpdateName(Guid id, string name);
        void DeleteOne(Guid id);
    }
}