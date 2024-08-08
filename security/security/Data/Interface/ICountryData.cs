using System.Collections.Generic;
using System.Threading.Tasks;
using Data.DTO;
using Entity.Model.Security;

namespace Data.Implements
{
    public interface ICountryData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<CountryDto>> GetAll();
        Task<Country> Save(Country entity);
        Task Update(Country entity);
        Task<Country> GetById(int id);
        Task<IEnumerable<CountryDto>> GetListCountries();
    }
}
