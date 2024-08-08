using Data.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebC.Controllers.Interfaces
{
    public interface IModuleController
    {
        Task<ActionResult<IEnumerable<ModuleDto>>> GetAll();
        Task<ActionResult<ModuleDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<ModuleDto>> Save([FromBody] ModuleDto entity);
        Task<IActionResult> Update(int id, ModuleDto entity);
        Task<IActionResult> Delete(int id);
    }
}
