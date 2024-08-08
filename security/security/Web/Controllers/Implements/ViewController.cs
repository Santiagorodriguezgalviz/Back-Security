
using Bunnisses.Security.Interface;
using Data.Dto;
using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using WebC.Controllers.Interfaces;

namespace WebC.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]
    public class ViewController : ControllerBase, IViewController
    {
        private readonly IViewBusiness _ViewBusiness;

        public ViewController(IViewBusiness ViewBusiness)
        {
            _ViewBusiness = ViewBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewDto>>> GetAll()
        {
            var result = await _ViewBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ViewDto>> GetById(int id)
        {
            var result = await _ViewBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _ViewBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ViewDto>> Save([FromBody] ViewDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _ViewBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ViewDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _ViewBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _ViewBusiness.Delete(id);
            return NoContent();
        }

        [HttpGet("Nombre/{nombre}")]
        public async Task<ActionResult<ViewDto>> GetByNombre(string nombre)
        {
            var result = await _ViewBusiness.GetByNombre(nombre);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
