using Microsoft.EntityFrameworkCore;
using RoleService.Models;

namespace RoleService.Data
{
    public class RolesDatabaseContext : DbContext
    {
        public RolesDatabaseContext(DbContextOptions<RolesDatabaseContext> options) : base(options)
        {
            //
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
