using Data.Dto;
using Data.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebC.Controllers.Interfaces
{
    public interface IViewController
    {
        Task<ActionResult<IEnumerable<ViewDto>>> GetAll();
        Task<ActionResult<ViewDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<ViewDto>> Save([FromBody] ViewDto entity);
        Task<IActionResult> Update(int id, ViewDto entity);
        Task<IActionResult> Delete(int id);
        Task<ActionResult<ViewDto>> GetByNombre(string nombre);
    }
}
