using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using RoleService.Repositories;
using RoleService.Models;
using RoleService.DTOs;

namespace RoleService.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/user-roles")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleController(IRoleRepository roleRepository, IUserRoleRepository userRoleRepository)
        {
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Role> GetUserRoles(Guid userId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{userId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Role> CreateUserRole([FromBody] CreateUserRoleRequest request)
        {
            Role role = _roleRepository.GetById(request.RoleId);
            if (role == null)
            {
                return NotFound("Role not found");
            }

            UserRole userRole = new UserRole
            {
                UserId = request.UserId,
                RoleId = request.RoleId,
                CreateDate = DateTime.Now
            };

            _roleRepository.Create(role);

            return Created(nameof(Role), role);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Role> Delete(Guid id, DeleteRoleRequest request)
        {
            UserRole userRole = _userRoleRepository.GetById(id);
            if (userRole == null)
            {
                return NotFound("User role not found");
            }

            _userRoleRepository.Remove(id);

            return Ok();
        }
    }
}
