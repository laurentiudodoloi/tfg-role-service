using RoleService.Models;
using System;
using System.Collections.Generic;

namespace RoleService.Repositories
{
    public interface IUserRoleRepository : IRepository<UserRole>
    {
        public IEnumerable<Role> GetUserRoles(Guid userId);
    }
}
