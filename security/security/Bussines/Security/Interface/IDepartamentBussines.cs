using System.Collections.Generic;
using System.Threading.Tasks;
using Data.DTO;
using Entity.Model.Security;

namespace Bunnisses.Security.Interface
{
    public interface IDepartamentBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<DepartamentDto>> GetAll();
        Task<DepartamentDto> GetById(int id);
        Task<Departament> Save(DepartamentDto entity);
        Task Update(int id, DepartamentDto entity);
    }
}
