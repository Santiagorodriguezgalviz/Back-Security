using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controller.Interface
{
    public interface IDepartamentController
    {
        Task<ActionResult<IEnumerable<DepartamentDto>>> GetAll();
        Task<ActionResult<DepartamentDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<DepartamentDto>> Save([FromBody] DepartamentDto entity);
        Task<IActionResult> Update(int id, DepartamentDto entity);
        Task<IActionResult> Delete(int id);
    }
}
