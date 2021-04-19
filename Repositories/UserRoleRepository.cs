using RoleService.Data;
using RoleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoleService.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly RolesDatabaseContext _context;

        public UserRoleRepository(RolesDatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserRole>> GetAll() => _context.UserRoles.ToList();

        public async Task<UserRole> Create(UserRole entity)
        {
            UserRole userRole = await _context.UserRoles.AddAsync(entity);
            await _context.SaveChangesAsync();

            return userRole;
        }

        public async Task<UserRole> GetById(Guid id) => await _context.UserRoles.FindAsync(id);

        public async Task<bool> Remove(Guid id)
        {
            UserRole userRole = _context.UserRoles.Find(id);
            if (userRole == null)
            {
                return false;
            }

            _context.UserRoles.Remove(userRole);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Role>> GetUserRoles(Guid userId)
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
