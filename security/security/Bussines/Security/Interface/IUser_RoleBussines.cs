using Data.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunnisses.Security.Interface
{
    public interface IUser_RoleBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<User_RoleDto>> GetAll();
        Task<User_RoleDto> GetById(int id);
        Task<User_role> Save(User_RoleDto entity);
        Task Update(int id, User_RoleDto entity);
    }
}
