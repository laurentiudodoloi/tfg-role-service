using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RoleService.Models
{
    public class Role : BaseModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public virtual ICollection<Role> UserRoles { get; set; }
    }
}
