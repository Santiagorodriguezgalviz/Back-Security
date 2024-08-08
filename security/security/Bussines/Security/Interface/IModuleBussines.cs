using Data.DTO;

using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunnisses.Security.Interface
{
    public interface IModuleBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<ModuleDto>> GetAll();
        Task<ModuleDto> GetById(int id);
        Task<Module> Save(ModuleDto entity);
        Task Update(int id, ModuleDto entity);
    }
}
