using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoleService.Repositories
{
    public interface IRepository<TModel> where TModel : class
    {
        public Task<List<TModel>> GetAll();
        public Task<TModel> Create(TModel entity);
        public Task<TModel> GetById(Guid id);
        public Task<bool> Remove(Guid id);
    }
}
