using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using RoleService.Repositories;
using RoleService.Models;
using RoleService.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoleService.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Role>>> GetAll()
        {
            return Ok(await _roleRepository.GetAll());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Role>> Create([FromBody] CreateRoleRequest request)
        {
            Role role = new Role
            {
                Name = request.Name,
                CreateDate = DateTime.Now
            };

            role = await _roleRepository.Create(role);

            return CreatedAtAction(nameof(Role), role);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<Role>> Delete(Guid id)
        {
            Role role = await _roleRepository.GetById(id);
            if (role == null)
            {
                return NotFound("Role not found");
            }

            await _roleRepository.Remove(id);

            return NoContent();
        }
    }
}
