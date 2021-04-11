using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace RoleService.Models
{
    public class User : BaseModel
    {
        public Guid Id { get; set; }
    }
}
