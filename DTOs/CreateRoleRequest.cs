using MediatR;
using RoleService.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace RoleService.DTOs
{
    public class CreateRoleRequest : IRequest<Role>
    {

        [Required(ErrorMessage = "Field is empty")]
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
