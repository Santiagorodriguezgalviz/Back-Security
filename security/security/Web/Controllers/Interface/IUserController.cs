using Data.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace WebC.Controllers.Interfaces
{
    public interface IUserController
    {
        Task<ActionResult<IEnumerable<UserDto>>> GetAll();
        Task<ActionResult<UserDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<UserDto>> Save([FromBody] UserDto entity);
        Task<IActionResult> Update(int id, UserDto entity);
        Task<IActionResult> Delete(int id);
        Task<ActionResult<UserDto>> GetByUsername(User user, int Id);
        Task<ActionResult<UserDto>> GetByPassword(User user, int Id);
      
    }
}
