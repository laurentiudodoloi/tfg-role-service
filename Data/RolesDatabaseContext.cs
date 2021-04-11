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
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
    }
}
