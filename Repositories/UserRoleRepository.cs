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

        public IEnumerable<Role> GetUserRoles(Guid userId)
        {
            var x = from u in _context.Users
                    from r in _context.Roles
                    from ur in _context.UserRoles
                    where u.Id == userId
                    where u.Id == ur.UserId
                    where r.Id == ur.RoleId
                    select r;

            return x.ToList<Role>();
        }
    }
}
