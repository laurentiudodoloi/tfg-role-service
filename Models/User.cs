using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace RoleService.Models
{
    public class User : BaseModel
    {
        public Guid Id { get; set; }

        public static implicit operator User(EntityEntry<User> v)
        {
            throw new NotImplementedException();
        }
    }
}
