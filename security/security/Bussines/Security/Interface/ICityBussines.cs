using System.Collections.Generic;
using System.Threading.Tasks;
using Data.DTO;
using Entity.Model.Security;

namespace Bunnisses.Security.Interface
{
    public interface ICityBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<CityDto>> GetAll();
        Task<CityDto> GetById(int id);
        Task<City> Save(CityDto entity);
        Task Update(int id, CityDto entity);
    }
}
