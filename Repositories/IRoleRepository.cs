using RoleService.Models;
using System.Threading.Tasks;

namespace RoleService.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role> GetByName(string name);
        Task<bool> Cleanup();
    }
}
