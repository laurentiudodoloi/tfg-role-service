using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using RoleService.Repositories;
using RoleService.Models;
using RoleService.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;

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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Role>>> GetUserRoles(Guid userId)
        {
            User user = await _userRepository.GetById(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(await _userRoleRepository.GetUserRoles(userId));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Role>> CreateUserRole([FromBody] CreateUserRoleRequest request)
        {
            Role role = await _roleRepository.GetById(request.RoleId);
            if (role == null)
            {
                return NotFound("Role not found");
            }

            User user = await _userRepository.GetById(request.UserId);
            if (user == null)
            {
                user = new User
                {
                    Id = request.UserId
                };

                await _userRepository.Create(user);
            }

            UserRole userRole = new UserRole
            {
                UserId = request.UserId,
                RoleId = request.RoleId,
                CreateDate = DateTime.Now
            };

            await _userRoleRepository.Create(userRole);

            return Created(nameof(UserRole), null);
        }
    }
}
