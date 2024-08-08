using Data.DTO;
using Data.Implementations;
using Entity.Model.Security;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunnisses.Security.Interface
{
    public interface IPersonBussines
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<PersonDto>> GetAll();
        Task<PersonDto> GetById(int id);
        Task<Person> Save(PersonDto entity);
        Task Update(int id, PersonDto entity);
        Task<Person> GetByFirst_name(string firstName);
    }
}
