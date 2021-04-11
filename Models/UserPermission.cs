using System;

namespace RoleService.Models
{
    public class UserPermission : BaseModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid PermissionId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
