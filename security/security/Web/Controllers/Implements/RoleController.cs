using Bunnisses.Security.Interface;
using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using WebC.Controllers.Interfaces;

namespace Web.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]

    public class RoleController : ControllerBase, IRoleController
    {
        private readonly IRolBusiness _RolBusiness;

        public RoleController(IRolBusiness RolBusiness)
        {
            _RolBusiness = RolBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetAll()
        {
            var result = await _RolBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDto>> GetById(int id)
        {
            var result = await _RolBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _RolBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<RoleDto>> Save([FromBody] RoleDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _RolBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RoleDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _RolBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _RolBusiness.Delete(id);
            return NoContent();
        }

    }
}
