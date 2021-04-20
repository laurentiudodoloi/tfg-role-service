using RoleService.Data;
using RoleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoleService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RolesDatabaseContext _context;

        public UserRepository(RolesDatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAll() => _context.Users.ToList();

        public async Task<User> Create(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<User> GetById(Guid id) => await _context.Users.FindAsync(id);

        public async Task<bool> Remove(Guid id)
        {
            User user = _context.Users.Find(id);
            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
