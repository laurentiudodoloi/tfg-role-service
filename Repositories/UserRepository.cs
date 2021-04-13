using RoleService.Data;
using RoleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoleService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RolesDatabaseContext _context;

        public UserRepository(RolesDatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(Guid id)
        {
            return _context.Users.Find(id);
        }

        public void Create(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(Guid id)
        {
            User user = _context.Users.Find(id);

            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
