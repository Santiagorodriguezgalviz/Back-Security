
using Data.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controller.Interface
{
    public interface IPersonController
    {
        Task<ActionResult<IEnumerable<PersonDto>>> GetAll();
        Task<ActionResult<PersonDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<PersonDto>> Save([FromBody] PersonDto entity);
        Task<IActionResult> Update(int id, PersonDto entity); 
        Task<IActionResult> Delete(int id);
        Task<ActionResult<PersonDto>> GetByFirst_name(string firstName);
    }
}
