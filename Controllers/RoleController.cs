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
        public IActionResult GetAll()
        {
            return Ok(_roleRepository.GetAll());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Role> Create([FromBody] CreateRoleRequest request)
        {
            Role role = new Role
            {
                Name = request.Name,
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
            Role role = _roleRepository.GetById(id);
            if (role == null)
            {
                return NotFound();
            }

            _roleRepository.Remove(id);

            return Ok();
        }
    }
}
