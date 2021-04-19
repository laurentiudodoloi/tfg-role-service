using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public static implicit operator Role(EntityEntry<Role> v)
        {
            throw new NotImplementedException();
        }
    }
}
