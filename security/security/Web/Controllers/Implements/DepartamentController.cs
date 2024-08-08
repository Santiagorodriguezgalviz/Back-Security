using Bunnisses.Security.Interface;
using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Controller.Interface;


namespace WebC.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]
    public class DepartamentController : ControllerBase, IDepartamentController
    {
        private readonly IDepartamentBusiness _departamentBusiness;

        public DepartamentController(IDepartamentBusiness departamentBusiness)
        {
            _departamentBusiness = departamentBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartamentDto>>> GetAll()
        {
            var result = await _departamentBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartamentDto>> GetById(int id)
        {
            var result = await _departamentBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _departamentBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<DepartamentDto>> Save([FromBody] DepartamentDto entity)
        {
            if (entity == null || string.IsNullOrWhiteSpace(entity.Nombre))
            {
                return BadRequest("Entity or Nombre is null or empty");
            }
            var result = await _departamentBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DepartamentDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _departamentBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _departamentBusiness.Delete(id);
            return NoContent();
        }
    }
}
