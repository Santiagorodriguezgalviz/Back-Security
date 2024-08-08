using Data.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunnisses.Security.Interface
{
    public interface IRolBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<RoleDto>> GetAll();
        Task<RoleDto> GetById(int id);
        Task<Role> Save(RoleDto entity);
        Task Update(int id, RoleDto entity);
    }
}
