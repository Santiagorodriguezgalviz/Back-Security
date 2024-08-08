using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controller.Interface
{
    public interface ICountryController
    {
        Task<ActionResult<IEnumerable<CountryDto>>> GetAll();
        Task<ActionResult<CountryDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<CountryDto>> Save([FromBody] CountryDto entity);
        Task<IActionResult> Update(int id, CountryDto entity);
        Task<IActionResult> Delete(int id);
    }
}
