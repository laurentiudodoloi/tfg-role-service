using RoleService.Models;
using System;
using System.Collections.Generic;

namespace RoleService.Repositories
{
    public interface IRepository<TModel> where TModel : class
    {
        IEnumerable<TModel> GetAll();
        public void Create(TModel role);
        public TModel GetById(Guid id);
        public void Remove(Guid id);
    }
}
