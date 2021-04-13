using RoleService.Data;
using RoleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoleService.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RolesDatabaseContext _context;

        public RoleRepository(RolesDatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Role> GetAll()
        {
            return _context.Roles.ToList();
        }

        public Role GetById(Guid id)
        {
            return _context.Roles.Find(id);
        }

        public void Create(Role entity)
        {
            _context.Roles.Add(entity);
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
