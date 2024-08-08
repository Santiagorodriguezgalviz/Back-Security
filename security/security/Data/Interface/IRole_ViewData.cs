using Data.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRole_ViewData
    {
        public Task Delete(int id);
        public Task<IEnumerable<Rol_ViewDto>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<Role_View> GetById(int id);
        public Task<Role_View> Save(Role_View entity);
        public Task Update(Role_View entity);

        public Task<IEnumerable<View>> GetViewsForRole(int roleId);
    }
}
