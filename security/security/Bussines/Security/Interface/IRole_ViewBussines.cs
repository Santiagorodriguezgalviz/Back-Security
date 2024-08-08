using Data.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunnisses.Security.Interface
{
    public interface IRole_ViewBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<Rol_ViewDto>> GetAll();
        Task<Rol_ViewDto> GetById(int id);
        Task<Role_View> Save(Rol_ViewDto entity);
        Task Update(int id, Rol_ViewDto entity);
    }
}
