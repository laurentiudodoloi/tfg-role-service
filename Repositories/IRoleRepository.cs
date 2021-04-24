using RoleService.Models;
using System.Threading.Tasks;

namespace RoleService.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<bool> Cleanup();
    }
}
