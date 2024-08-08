
using Bunnisses.Security.Implements;
using Bunnisses.Security.Interface;
using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using WebC.Controllers.Interfaces;

namespace WebC.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]
    public class Role_ViewController : ControllerBase, IRole_ViewController
    {
        private readonly IRole_ViewBusiness _Role_ViewBusiness;

        public Role_ViewController(IRole_ViewBusiness Role_ViewBusiness)
        {
            _Role_ViewBusiness = Role_ViewBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rol_ViewDto>>> GetAll()
        {
            var result = await _Role_ViewBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rol_ViewDto>> GetById(int id)
        {
            var result = await _Role_ViewBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _Role_ViewBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Rol_ViewDto>> Save([FromBody] Rol_ViewDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _Role_ViewBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Rol_ViewDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _Role_ViewBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _Role_ViewBusiness.Delete(id);
            return NoContent();
        }
    }
}
