﻿using RoleService.Data;
using RoleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoleService.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RolesDatabaseContext _context;

        public RoleRepository(RolesDatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetAll() => _context.Roles.ToList();

        public async Task<Role> GetById(Guid id) => await _context.Roles.FindAsync(id);

        public async Task<Role> Create(Role entity)
        {
            Role role = await _context.Roles.AddAsync(entity);
            await _context.SaveChangesAsync();

            return role;
        }

        public async Task<bool> Remove(Guid id)
        {
            Role role = _context.Roles.Find(id);
            if (role == null)
            {
                return false;
            }

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
