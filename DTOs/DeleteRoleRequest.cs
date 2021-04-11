using MediatR;
using RoleService.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace RoleService.DTOs
{
    public class DeleteRoleRequest: IRequest<Role>
    {
        public Guid Id { get; set; }
    }
}
