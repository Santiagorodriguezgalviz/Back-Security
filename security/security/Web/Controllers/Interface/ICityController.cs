using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controller.Interface
{
    public interface ICityController
    {
        Task<ActionResult<IEnumerable<CityDto>>> GetAll();
        Task<ActionResult<CityDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<CityDto>> Save([FromBody] CityDto entity);
        Task<IActionResult> Update(int id, CityDto entity);
        Task<IActionResult> Delete(int id);
    }
}
