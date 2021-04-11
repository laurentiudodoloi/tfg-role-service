using RoleService.Data;
using RoleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoleService.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly RolesDatabaseContext _context;

        public UserRoleRepository(RolesDatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<UserRole> GetAll()
        {
            return _context.UserRoles.ToList();
        }

        public UserRole GetById(Guid id)
        {
            return _context.UserRoles.Find(id);
        }

        public void Create(UserRole role)
        {
            _context.UserRoles.Add(role);
            _context.SaveChanges();
        }

        public void Remove(Guid id)
        {
            Role role = _context.Roles.Find(id);

            _context.Roles.Remove(role);
            _context.SaveChanges();
        }
    }
}
