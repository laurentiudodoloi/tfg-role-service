using RoleService.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoleService.Repositories
{
    public interface IUserRoleRepository : IRepository<UserRole>
    {
        public Task<IEnumerable<Role>> GetUserRoles(Guid userId);
    }
}
