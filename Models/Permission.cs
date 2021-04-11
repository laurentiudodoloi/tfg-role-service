using System;

namespace RoleService.Models
{
    public class Permission : BaseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
