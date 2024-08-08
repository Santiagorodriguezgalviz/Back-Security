using System.Collections.Generic;
using System.Threading.Tasks;
using Data.DTO;
using Entity.Model.Security;

namespace Bunnisses.Security.Interface
{
    public interface ICountryBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<CountryDto>> GetAll();
        Task<CountryDto> GetById(int id);
        Task<Country> Save(CountryDto entity);
        Task Update(int id, CountryDto entity);
    }
}
