using Data.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebC.Controllers.Interfaces
{
    public interface IRoleController
    {
        Task<ActionResult<IEnumerable<RoleDto>>> GetAll();
        Task<ActionResult<RoleDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<RoleDto>> Save([FromBody] RoleDto entity);
        Task<IActionResult> Update(int id, RoleDto entity);
        Task<IActionResult> Delete(int id);
    }
}
