using Data.Dto;
using Data.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implements
{
    public interface IRoleData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Role> Save(Role entity);
        Task Update(Role entity);
        Task<Role> GetById(int id);
        Task<IEnumerable<RoleDto>> GetAll();
    }
}
