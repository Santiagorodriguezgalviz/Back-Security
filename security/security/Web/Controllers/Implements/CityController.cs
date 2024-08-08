using Bunnisses.Security.Interface;
using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Web.Controller.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace WebC.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase, ICityController
    {
        private readonly ICityBusiness _cityBusiness;

        public CityController(ICityBusiness cityBusiness)
        {
            _cityBusiness = cityBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetAll()
        {
            var result = await _cityBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CityDto>> GetById(int id)
        {
            var result = await _cityBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _cityBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CityDto>> Save([FromBody] CityDto entity)
        {
            if (entity == null || string.IsNullOrWhiteSpace(entity.Nombre))
            {
                return BadRequest("Entity or Nombre is null or empty");
            }
            var result = await _cityBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CityDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _cityBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _cityBusiness.Delete(id);
            return NoContent();
        }
    }
}
