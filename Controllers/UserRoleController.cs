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
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleController(
            IRoleRepository roleRepository,
            IUserRepository userRepository,
            IUserRoleRepository userRoleRepository
        ) {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Role> GetUserRoles(Guid userId)
        {
            User user = _userRepository.GetById(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(_userRoleRepository.GetUserRoles(userId));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Role> CreateUserRole([FromBody] CreateUserRoleRequest request)
        {
            Role role = _roleRepository.GetById(request.RoleId);
            if (role == null)
            {
                return NotFound("Role not found");
            }

            User user = _userRepository.GetById(request.UserId);
            if (user == null)
            {
                user = new User
                {
                    Id = request.UserId
                };
                _userRepository.Create(user);
            }

            UserRole userRole = new UserRole
            {
                UserId = request.UserId,
                RoleId = request.RoleId,
                CreateDate = DateTime.Now
            };

            _userRoleRepository.Create(userRole);

            return Created(nameof(UserRole), null);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Role> Delete(Guid id, DeleteRoleRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
