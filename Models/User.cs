using System;
using System.Collections.Generic;

namespace RoleService.Models
{
    public class User : BaseModel
    {
        public Guid Id { get; set; }
        public virtual ICollection<Role> UserRoles { get; set; }
    }
}
