using Bunnisses.Security.Interface;
using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using WebC.Controllers.Interfaces;

namespace WebC.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]

    public class UsuarioRolController : ControllerBase, IUser_RoleController
    {
        private readonly IUser_RoleBusiness _User_RoleBusiness;

        public UsuarioRolController(IUser_RoleBusiness User_RoleBusiness)
        {
            _User_RoleBusiness = User_RoleBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User_RoleDto>>> GetAll()
        {
            var result = await _User_RoleBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User_RoleDto>> GetById(int id)
        {
            var result = await _User_RoleBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _User_RoleBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<User_RoleDto>> Save([FromBody] User_RoleDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _User_RoleBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] User_RoleDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _User_RoleBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _User_RoleBusiness.Delete(id);
            return NoContent();
        }

    }
}
