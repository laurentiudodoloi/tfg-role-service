using System;

namespace RoleService.Models
{
    public class UserRole : BaseModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
