using Microsoft.EntityFrameworkCore;
using RoleService.Models;

namespace RoleService.Data
{
    public class RolesDatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public RolesDatabaseContext(DbContextOptions<RolesDatabaseContext> options) : base(options)
        {
            //
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasKey(userRole => new { userRole.UserId, userRole.RoleId });
        }
    }
}
