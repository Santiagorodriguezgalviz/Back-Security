using Entity.Model.Contexts;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Data.Implements;
using Data.Dto;

namespace Data.Implementations
{
    public class UserData : IUserData
    {
        private readonly ApplicationDbContexts context;
        protected readonly IConfiguration configuration;

        public string Nombre_Usuario { get; private set; }

        public UserData(ApplicationDbContexts context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity.Deleted_at = DateTime.Parse(DateTime.Today.ToString());
            context.user.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Nombre_usuario, ' - ', Contraseña) AS TextoMostrar 
                    FROM 
                        [user]
                    WHERE Deleted_at IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var sql = @"SELECT
                Id,
                Nombre_usuario,
                Contraseña,
                PersonId,
                RoleId,
                Role,
                Person,
                State,
            FROM [user]
            WHERE p.deleted_at IS NULL
            ORDER BY p.Id ASC";

            return await context.QueryAsync<UserDto>(sql);
        }

        public async Task<User> GetById(int id)
        {
            var sql = @"SELECT * FROM [user] WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
        }


        public async Task<User> Save(User entity)
        {
            context.user.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(User entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public Task<User> GetByUsername(User user, int Id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByPassword(User user, int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> Login(string Nombre_usuario, string contraseña)
        {
            var sql = @"SELECT u.Id, u.Nombre_usuario, u.Contraseña, u.PersonId, u.RoleId, u.State, u.Created_at, u.Updated_at, u.Deleted_at 
                        FROM [user] u
                        WHERE u.Nombre_usuario = @Nombre_usuario AND u.Contraseña = @Contraseña AND u.Deleted_at IS NULL";
            var user = await this.context.QueryFirstOrDefaultAsync<UserDto>(sql, new { Nombre_usuario = Nombre_usuario, contraseña = contraseña });

            if (user == null)
            {
                throw new UnauthorizedAccessException("Usuario no encontrado o contraseña incorrecta.");
            }

            return user;
        }
    }
}