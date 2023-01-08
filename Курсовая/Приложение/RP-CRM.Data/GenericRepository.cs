using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RP_CRM.Data
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task AddOrUpdate(T entity);
        Task Delete(Guid id);
        IAsyncEnumerable<T> GetAll();
        Task<T> GetById(Guid id);
        Task<Guid> GetIdByName(string name);
    }

    
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        private readonly DatabaseContext _databaseContext;

        public GenericRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task AddOrUpdate(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> GetIdByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}