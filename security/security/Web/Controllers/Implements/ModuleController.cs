using Bunnisses.Security.Interface;
using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using WebC.Controllers.Interfaces;

namespace WebC.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]
    public class ModuleController : ControllerBase, IModuleController
    {
        private readonly IModuleBusiness _ModuleBusiness;

        public ModuleController(IModuleBusiness ModuleBusiness)
        {
            _ModuleBusiness = ModuleBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModuleDto>>> GetAll()
        {
            var result = await _ModuleBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ModuleDto>> GetById(int id)
        {
            var result = await _ModuleBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _ModuleBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ModuleDto>> Save([FromBody] ModuleDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _ModuleBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ModuleDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _ModuleBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _ModuleBusiness.Delete(id);
            return NoContent();
        }
    }
}
