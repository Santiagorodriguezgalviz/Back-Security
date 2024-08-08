using Bunnisses.Security.Implemetations;
using Bunnisses.Security.Interface;
using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Web.Controller.Interface;


namespace WebC.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]

    public class PersonController : ControllerBase, IPersonController
    {
        private readonly IPersonBussines _PersonBussines;


        public PersonController(IPersonBussines PersonBussines)
        {
            _PersonBussines = PersonBussines;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDto>>> GetAll()
        {
            var result = await _PersonBussines.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDto>> GetById(int id)
        {
            var result = await _PersonBussines.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _PersonBussines.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<PersonDto>> Save([FromBody] PersonDto entity)
        {
            if (entity == null || string.IsNullOrWhiteSpace(entity.Direccion))
            {
                return BadRequest("Entity or Direccion is null or empty");
            }
            var result = await _PersonBussines.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PersonDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _PersonBussines.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _PersonBussines.Delete(id);
            return NoContent();
        }

        [HttpGet("primer_nombre/{firstName}")]  
        public async Task<ActionResult<PersonDto>> GetByFirst_name(string firstName)
        {
            var result = await _PersonBussines.GetByFirst_name(firstName);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
