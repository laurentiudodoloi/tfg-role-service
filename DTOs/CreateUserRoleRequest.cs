using MediatR;
using RoleService.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace RoleService.DTOs
{
    public class CreateUserRoleRequest : IRequest<Role>
    {
        [Required(ErrorMessage = "Field is empty")]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Field is empty")]
        public Guid RoleId { get; set; }
    }
}
