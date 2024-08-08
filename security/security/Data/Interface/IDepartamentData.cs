using System.Collections.Generic;
using System.Threading.Tasks;
using Data.DTO;
using Entity.Model.Security;

namespace Data.Implements
{
    public interface IDepartamentData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<DepartamentDto>> GetAll();
        Task<Departament> Save(Departament entity);
        Task Update(Departament entity);
        Task<Departament> GetById(int id);
        Task<IEnumerable<DepartamentDto>> GetListDepartaments();
    }
}
