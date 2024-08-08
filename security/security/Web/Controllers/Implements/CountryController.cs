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
    public class CountryController : ControllerBase, ICountryController
    {
        private readonly ICountryBusiness _countryBusiness;

        public CountryController(ICountryBusiness countryBusiness)
        {
            _countryBusiness = countryBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryDto>>> GetAll()
        {
            var result = await _countryBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetById(int id)
        {
            var result = await _countryBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _countryBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CountryDto>> Save([FromBody] CountryDto entity)
        {
            if (entity == null || string.IsNullOrWhiteSpace(entity.Nombre))
            {
                return BadRequest("Entity or Nombre is null or empty");
            }
            var result = await _countryBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CountryDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _countryBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _countryBusiness.Delete(id);
            return NoContent();
        }
    }
}
