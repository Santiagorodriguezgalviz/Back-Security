using Data.DTO;

using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUser_roleData
    {
        public Task Delete(int id);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<IEnumerable<User_RoleDto>> GetAll();
        public Task<User_role> GetById(int id);
        public Task<User_role> Save(User_role entity);
        public Task Update(User_role entity);
    }
}
