using Data.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebC.Controllers.Interfaces
{
    public interface IUser_RoleController
    {
        Task<ActionResult<IEnumerable<User_RoleDto>>> GetAll();
        Task<ActionResult<User_RoleDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<User_RoleDto>> Save([FromBody] User_RoleDto entity);
        Task<IActionResult> Update(int id, User_RoleDto entity);
        Task<IActionResult> Delete(int id);
    }
}
