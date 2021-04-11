using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoleService.Models
{
    public class UserRole : BaseModel
    {
        public Guid Id { get; set; }

        [Column(Order = 1)]
        public Guid UserId { get; set; }

        [Column(Order = 2)]
        public Guid RoleId { get; set; }

        public User User { get; set; }

        public Role Role { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
