using Bunnisses.Security.Interface;
using Data.DTO;
using Data.Interfaces;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunnisses.Security.Implements
{
    public class User_RoleBusiness : IUser_RoleBusiness
    {
        private readonly IUser_roleData data;

        public User_RoleBusiness(IUser_roleData data)
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

        public async Task<IEnumerable<User_RoleDto>> GetAll()
        {
            return await this.data.GetAll();
        }


        public async Task<User_RoleDto> GetById(int id)
        {
            User_role userRol = await this.data.GetById(id);
            User_RoleDto User_RoleDto = new User_RoleDto();

            {
                User_RoleDto.Id = userRol.Id;
                User_RoleDto.UserId = userRol.UserId;
                User_RoleDto.RoleId = userRol.RoleId;
                User_RoleDto.user = userRol.user;
                User_RoleDto.role = userRol.role;
                User_RoleDto.State = userRol.State;

                return User_RoleDto;
            }

        }

        public async Task<User_role> Save(User_RoleDto entity)
        {
            User_role  userRol = new User_role();
            userRol = this.mapearDatos(userRol, entity);
  
            return await data.Save(userRol);
        }


        public async Task Update(int Id, User_RoleDto entity)
        {
            User_role userRol = await this.data.GetById(Id);
            if (userRol == null)
            {
                throw new ArgumentNullException("Registro no encontrado", nameof(entity));
            }
            userRol = this.mapearDatos(userRol, entity);

            await this.data.Update(userRol);
        }


        private User_role mapearDatos(User_role userRol, User_RoleDto entity)
        {
            userRol.Id = entity.Id;
            userRol.UserId = entity.UserId;
            userRol.RoleId = entity.RoleId;
            userRol.user = entity.user;
            userRol.role = entity.role;
            userRol.State = entity.State;

            return userRol;
        }
    }
}
