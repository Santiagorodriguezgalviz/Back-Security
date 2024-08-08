using Data.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebC.Controllers.Interfaces
{
    public interface IRole_ViewController
    {
        Task<ActionResult<IEnumerable<Rol_ViewDto>>> GetAll();
        Task<ActionResult<Rol_ViewDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<Rol_ViewDto>> Save([FromBody] Rol_ViewDto entity);
        Task<IActionResult> Update(int id, Rol_ViewDto entity);
        Task<IActionResult> Delete(int id);
    }
}
