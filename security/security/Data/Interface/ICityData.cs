using System.Collections.Generic;
using System.Threading.Tasks;
using Data.DTO;
using Entity.Model.Security;

namespace Data.Implements
{
    public interface ICityData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<CityDto>> GetAll();
        Task<City> Save(City entity);
        Task Update(City entity);
        Task<City> GetById(int id);
        Task<IEnumerable<CityDto>> GetListCities();
    }
}
