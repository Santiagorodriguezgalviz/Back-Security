using Data.Dto;
using Data.DTO;
using Data.Implementations;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implements
{
    public interface IPersonData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<PersonDto>> GetAll();
        Task<Person> Save(Person entity);
        Task Update(Person entity);

        Task<Person> GetById(int id);

        Task<Person> GetByFirst_name(string firstName);
    }
}
