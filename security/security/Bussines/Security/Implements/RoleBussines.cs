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
    public class RoleBusiness : IRolBusiness
    {
        private readonly IRoleData data;

        public RoleBusiness(IRoleData data)
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

        public async Task<IEnumerable<RoleDto>> GetAll()
        {
            return await this.data.GetAll();
        }

        public async Task<RoleDto> GetById(int id)
        {
            Role rol = await this.data.GetById(id);
            RoleDto rolDto = new RoleDto();

            {
                rolDto.Id = rol.Id;
                rolDto.Nombre = rol.Nombre;
                rolDto.Descripcion = rol.Descripcion;
                rolDto.State = rol.State;

                return rolDto;
            };
        }

        public async Task<Role> Save(RoleDto entity)
        {
            Role rol = new Role();
            rol = this.mapearDatos(rol, entity);

            return await data.Save(rol);
        }

        public async Task Update(int Id, RoleDto entity)
        {
            Role rol = await this.data.GetById(Id);
            if (rol == null)
            {
                throw new ArgumentNullException("Registro no encontrado", nameof(entity));
            }
            rol = this.mapearDatos(rol, entity);

            await this.data.Update(rol);
        }

        private Role mapearDatos(Role rol, RoleDto entity)
        {
            rol.Id = entity.Id;
            rol.Nombre = entity.Nombre;
            rol.Descripcion = entity.Descripcion;
            rol.State = entity.State;

            return rol;
        }

   
   
    }
}
