using Bunnisses.Security.Interface;
using Data.DTO;
using Data.Implements;
using Data.Interfaces;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunnisses.Security.Implements
{
    public class ModuleBusiness : IModuleBusiness
    {
        private readonly IModuleData data;

        public ModuleBusiness(IModuleData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }

        public async Task<IEnumerable<ModuleDto>> GetAll()
        {
            return await this.data.GetAll();
        }


        public async Task<ModuleDto> GetById(int id)
        {
            Module module = await this.data.GetById(id);
            ModuleDto moduleDto = new ModuleDto();

            {
                moduleDto.Id = module.Id;
                moduleDto.Nombre = module.Nombre;
                moduleDto.Descripcion = module.Descripcion;
                moduleDto.State = module.State;

                return moduleDto;
            }
        }

        public async Task<Module> Save(ModuleDto entity)
        {
            Module module = new Module();
            module = this.mapearDatos(module, entity);

            return await data.Save(module);
        }


        public async Task Update(int Id, ModuleDto entity)
        {
            Module module = await this.data.GetById(Id);
            if (module == null)
            {
                throw new ArgumentNullException("Registro no encontrado", nameof(entity));
            }
            module = this.mapearDatos(module, entity);

            await this.data.Update(module);
        }


        private Module mapearDatos(Module module, ModuleDto entity)
        {
            module.Id = entity.Id;
            module.Nombre = entity.Nombre;
            module.Descripcion = entity.Descripcion;
            module.State = entity.State;

            return module;
        }
    }
}
