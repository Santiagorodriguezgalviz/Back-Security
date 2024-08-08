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
    public interface IModuleData
    {
        public Task Delete(int id);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<IEnumerable<ModuleDto>> GetAll();
        public Task<Module> Save(Module entity);
        public Task Update(Module entity);
        public Task<Module> GetById(int id);
        
    }
}
