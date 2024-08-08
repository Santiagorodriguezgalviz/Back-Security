using Bunnisses.Security.Interface;
using Data.DTO;
using Data.Implementations;
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
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserData data;

        public UserBusiness(IUserData data)
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
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            return await this.data.GetAll();
        }


        public async Task<UserDto> GetById(int id)
        {
            var user = await data.GetById(id);

            return new UserDto
            {
                Id = user.Id,
                Nombre_usuario = user.Nombre_usuario,
                Contraseña = user.Contraseña,
                PersonId = user.PersonId,
                RoleId = user.RoleId,
                State = user.State,
            };

        }

        public async Task<UserDto> Save(UserDto entity)
        {
            var user = new User
            {
                Nombre_usuario = entity.Nombre_usuario,
                Contraseña = entity.Contraseña,
                PersonId = entity.PersonId,
                RoleId = entity.RoleId,
                Created_at = DateTime.Now,
                State = entity.State,
            };

            var savedUser = await data.Save(user);
            return new UserDto
            {
                Id = savedUser.Id,
                Nombre_usuario = savedUser.Nombre_usuario,
                Contraseña = savedUser.Contraseña,
                PersonId = savedUser.PersonId,
                RoleId = savedUser.RoleId,
                Created_at = DateTime.Now,
                State = savedUser.State,
            };
        }

        public async Task Update(int Id, UserDto entity)
        {
            User user = await this.data.GetById(Id);
            if (user == null)
            {
                throw new ArgumentNullException("Registro no encontrado", nameof(entity));
            }
            user = this.mapearDatos(user, entity);

            await this.data.Update(user);
        }


        private User mapearDatos(User user, UserDto entity)
        {
            user.Id = entity.Id;
            user.Nombre_usuario = entity.Nombre_usuario;
            user.Contraseña = entity.Contraseña;
            user.PersonId = entity.PersonId;
            user.RoleId = entity.RoleId;
            user.Created_at = entity.Created_at;
            user.Updated_at = entity.Updated_at;
            user.Deleted_at = entity.Deleted_at;
            user.State = entity.State;
            return user;
        }

        public async Task<User> GetByUsername(User user, int Id)
        {
            return await this.data.GetByUsername(user, Id);
        }

        public async Task<User> GetByPassword(User user, int Id)
        {
            return await this.data.GetByPassword(user, Id);
        }

        public async Task<UserDto> Login(string Nombre_usuario, string contraseña)
        {
            if (string.IsNullOrEmpty(Nombre_usuario) || string.IsNullOrEmpty(contraseña))
            {
                throw new ArgumentException("El nombre de usuario y la contraseña son obligatorios.");
            }

            var user = await data.Login(Nombre_usuario, contraseña);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Usuario no encontrado o contraseña incorrecta.");
            }

            return new UserDto
            {
                Id = user.Id,
                Nombre_usuario = user.Nombre_usuario,
                Contraseña = user.Contraseña,
                PersonId = user.PersonId,
                RoleId = user.RoleId,
                State = user.State,
                Created_at = user.Created_at,
                Updated_at = user.Updated_at,
                Deleted_at = user.Deleted_at
            };
        }

    }
}